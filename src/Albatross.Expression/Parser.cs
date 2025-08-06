using System.Linq;
using System;
using System.Collections.Generic;
using Albatross.Expression.Exceptions;
using Albatross.Expression.Nodes;
using System.Diagnostics;

namespace Albatross.Expression {
	/// <summary>
	/// An immutable implementation of the <see cref="Albatross.Expression.IParser"/> interface.
	/// </summary>
	public class Parser : IParser {
		private readonly IReadOnlyList<IExpressionFactory<INode>> other_left;
		private readonly IReadOnlyList<IExpressionFactory<INode>> other_left_right;
		private readonly IReadOnlyList<IExpressionFactory<INode>> infix_comma_right;
		private readonly IReadOnlyList<IExpressionFactory<INode>> left_parenthesis_only;

		public Parser(IEnumerable<IExpressionFactory<INode>> factories) {
			var infix = new List<IExpressionFactory<INode>>();
			var others = new List<IExpressionFactory<INode>>();
			foreach (var factory in factories) {
				if (factory is IExpressionFactory<InfixExpression> infixFactory) {
					infix.Add(infixFactory);
				} else {
					others.Add(factory);
				}
			}
			this.other_left = others.Union([ControlTokenFactory.LeftParenthesis]).ToArray();
			this.other_left_right = others.Union([ControlTokenFactory.LeftParenthesis, ControlTokenFactory.RightParenthesis]).ToArray();
			this.infix_comma_right = infix.Union([ControlTokenFactory.Comma, ControlTokenFactory.RightParenthesis]).ToArray();
			this.left_parenthesis_only = [ControlTokenFactory.LeftParenthesis];
		}

		//parse an expression and produce queue of tokens
		//the expression is parse from left to right
		public Queue<INode> Tokenize(string expression) {
			var tokens = new Queue<INode>();
			int start = 0;
			while (start < expression.Length) {
				bool found = false;
				var last = tokens.LastOrDefault();
				IEnumerable<IExpressionFactory<INode>>? factories = null;
				if (last == null || last.IsComma() || last is UnaryExpression || last is InfixExpression) {
					factories = other_left;
				} else if (last.IsLeftParenthesis()) {
					factories = other_left_right;
				} else if (last.IsRightParenthesis() || last is IExpression) {
					factories = infix_comma_right;
				} else if (last is PrefixExpression) {
					factories = left_parenthesis_only;
				} else {
					Debug.Fail("Forgot to check an previous operation");
				}
				foreach (var factory in factories) {
					var node = factory.Parse(expression, start, out var next);
					if (node != null) {
						found = true;
						start = next;
						tokens.Enqueue(node);
						break;
					}
				}

				if (found) { continue; }

				if (start < expression.Length) {
					if (expression.Substring(start).Trim().Length == 0) {
						break;
					}
				}

				throw new TokenParsingException("Unexpected token: " + expression.Substring(start));
			}

			return tokens;
		}

		public bool IsValidExpression(string exp) {
			if (string.IsNullOrWhiteSpace(exp)) {
				return false;
			} else {
				try {
					Tokenize(exp);
					return true;
				} catch {
					return false;
				}
			}
		}

		public Stack<INode> BuildStack(Queue<INode> queue) {
			INode token;
			Stack<INode> postfix = new Stack<INode>();
			Stack<INode> stack = new Stack<INode>();

			while (queue.Count > 0) {
				token = queue.Dequeue();
				if (token == ControlTokenFactory.Comma) {
					//pop stack to postfix until we see left parenthesis
					while (stack.Count > 0 && stack.Peek() != ControlTokenFactory.LeftParenthesis) {
						postfix.Push(stack.Pop());
					}

					if (stack.Count == 0) {
						throw new StackException("misplace comma or missing left parenthesis");
					} else {
						continue;
					}
				}

				// if it is an operand, put it on the postfix stack
				if (token is IExpression) {
					postfix.Push(token);
				}

				if (token == ControlTokenFactory.LeftParenthesis) {
					stack.Push(token);
				} else if (token == ControlTokenFactory.RightParenthesis) {
					while (stack.Count > 0 && stack.Peek().IsLeftParenthesis(false)) {
						postfix.Push(stack.Pop());
					}

					if (stack.Count == 0) {
						throw new StackException("missing left parenthesis");
					} else {
						stack.Pop();
					}
				} else if (token is PrefixExpression) {
					stack.Push(token);
					postfix.Push(ControlTokenFactory.FuncParamStart.Token);
				} else if (token is InfixExpression) {
					if (stack.Count == 0 || stack.Peek().IsLeftParenthesis()) {
						stack.Push(token);
					} else {
						InfixExpression infix = (InfixExpression)token;
						while (stack.Count > 0
							   && stack.Peek().IsLeftParenthesis(false)
							   && (stack.Peek() is PrefixExpression
									|| stack.Peek() is InfixExpression
									&& infix.Precedence <= ((InfixExpression)stack.Peek()).Precedence)) {
							postfix.Push(stack.Pop());
						}

						stack.Push(token);
					}
				}
			}

			while (stack.Count > 0) {
				token = stack.Pop();
				if (token.IsLeftParenthesis()) {
					throw new TokenParsingException("unbalanced parentheses");
				} else {
					postfix.Push(token);
				}
			}

			return postfix;
		}

		public INode CreateTree(Stack<INode> postfix) {
			postfix = Reverse(postfix);
			Stack<INode> stack = new Stack<INode>();
			INode token;
			while (postfix.Count > 0) {
				token = postfix.Pop();
				if (token is IExpression || token.IsFuncParamStart()) {
					stack.Push(token);
				} else if (token is InfixExpression) {
					InfixExpression infixOp = (InfixExpression)token;
					infixOp.Operand2 = stack.Pop() as IExpression ?? throw new StackException("missing expression for infix operand1");
					infixOp.Operand1 = stack.Pop() as IExpression ?? throw new StackException("missing expression for infix operand2");
					stack.Push(infixOp);
				} else if (token is PrefixExpression prefixOp) {
					for (INode t = stack.Pop(); t.IsFuncParamStart(false); t = stack.Pop()) {
						prefixOp.Operands.Insert(0, t as IExpression ?? throw new StackException("missing expression for prefix operand"));
					}

					stack.Push(prefixOp);
				}
			}

			return stack.Pop();
		}

		public object? Eval(IExpression token, Func<string, object> context) {
			return token.Eval(context);
		}

		public string Text(INode token) {
			return token.Text();
		}

		public static Stack<T> Reverse<T>(Stack<T> src) {
			Stack<T> dst = new Stack<T>();
			while (src.Count > 0) {
				dst.Push(src.Pop());
			}

			return dst;
		}
	}
}