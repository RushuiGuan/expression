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
		public INode VariableToken() {
			return variable.Clone();
		}

		public IStringLiteral StringLiteralToken() {
			return (IStringLiteral)stringLiteralToken.Clone();
		}

		readonly List<PrefixExpression> prefixOperationTokens = new List<PrefixExpression>();
		readonly List<InfixExpression> infixOperationTokens = new List<InfixExpression>();
		INode variable;
		IStringLiteral stringLiteralToken;

		public Parser(IEnumerable<INode> operations, IVariable variable, IStringLiteral stringLiteralToken) {
			prefixOperationTokens.Clear();
			infixOperationTokens.Clear();

			this.variable = variable;
			this.stringLiteralToken = stringLiteralToken;
			foreach (var item in operations) {
				Add(item);
			}
		}

		IParser Add(INode token) {
			if (token is PrefixExpression) {
				prefixOperationTokens.Add((PrefixExpression)token);
			} else if (token is InfixExpression) {
				infixOperationTokens.Add((InfixExpression)token);
			} else {
				throw new NotSupportedException();
			}

			return this;
		}

		//parse an expression and produce queue of tokens
		//the expression is parse from left to right
		public Queue<INode> Tokenize(string expression) {
			if (string.IsNullOrEmpty(expression)) { throw new ArgumentException(); }
			var tokens = new Queue<INode>();
			int start = 0, next;
			INode? last;
			IEnumerable<INode>? list;
			bool found;
			while (start < expression.Length) {
				found = false;
				last = tokens.Count == 0 ? null : tokens.Last();
				list = null;
				if (last == null || last == ControlToken.Comma || ( last is PrefixExpression && ( (PrefixExpression)last ).Symbolic ) || last is InfixExpression) {
					list = new INode[] { new BooleanLiteral(), VariableToken(), StringLiteralToken(), new NumericLiteral(), ControlToken.LeftParenthesis }.Union(prefixOperationTokens);
				} else if (last == ControlToken.LeftParenthesis) {
					list = new INode[] { VariableToken(), StringLiteralToken(), new NumericLiteral(), ControlToken.LeftParenthesis, ControlToken.RightParenthesis }.Union(prefixOperationTokens);
				} else if (last == ControlToken.RightParenthesis || last is IExpression) {
					list = new INode[] { ControlToken.Comma, ControlToken.RightParenthesis }.Union(infixOperationTokens);
				} else if (last is PrefixExpression && !( (PrefixExpression)last ).Symbolic) {
					list = new INode[] { ControlToken.LeftParenthesis };
				}

				Debug.Assert(list != null, "Forgot to check an previous operation");
				foreach (INode token in list) {
					if (token.Match(expression, start, out next)) {
						found = true;
						start = next;
						if (token is PrefixExpression || token is InfixExpression) {
							tokens.Enqueue(token.Clone());
						} else {
							tokens.Enqueue(token);
						}

						break;
					}
				}

				if (found) {
					continue;
				}

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
				if (token == ControlToken.Comma) {
					//pop stack to postfix until we see left parenthesis
					while (stack.Count > 0 && stack.Peek() != ControlToken.LeftParenthesis) {
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

				if (token == ControlToken.LeftParenthesis) {
					stack.Push(token);
				} else if (token == ControlToken.RightParenthesis) {
					while (stack.Count > 0 && stack.Peek() != ControlToken.LeftParenthesis) {
						postfix.Push(stack.Pop());
					}

					if (stack.Count == 0) {
						throw new StackException("missing left parenthesis");
					} else {
						stack.Pop();
					}
				} else if (token is PrefixExpression) {
					stack.Push(token);
					postfix.Push(ControlToken.FuncParamStart);
				} else if (token is InfixExpression) {
					if (stack.Count == 0 || stack.Peek() == ControlToken.LeftParenthesis) {
						stack.Push(token);
					} else {
						InfixExpression infix = (InfixExpression)token;
						while (stack.Count > 0
						       && stack.Peek() != ControlToken.LeftParenthesis
						       && ( stack.Peek() is PrefixExpression
						            || stack.Peek() is InfixExpression
						            && infix.Precedence <= ( (InfixExpression)stack.Peek() ).Precedence )) {
							postfix.Push(stack.Pop());
						}

						stack.Push(token);
					}
				}
			}

			while (stack.Count > 0) {
				token = stack.Pop();
				if (token == ControlToken.LeftParenthesis) {
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
				if (token is IExpression || token == ControlToken.FuncParamStart) {
					stack.Push(token);
				} else if (token is InfixExpression) {
					InfixExpression infixOp = (InfixExpression)token;
					infixOp.Operand2 = stack.Pop();
					infixOp.Operand1 = stack.Pop();
					stack.Push(infixOp);
				} else if (token is PrefixExpression) {
					PrefixExpression prefixOp = (PrefixExpression)token;
					for (INode t = stack.Pop(); t != ControlToken.FuncParamStart; t = stack.Pop()) {
						prefixOp.Operands.Insert(0, t);
					}

					stack.Push(prefixOp);
				}
			}

			return stack.Pop();
		}

		public object? Eval(INode token, Func<string, object> context) {
			return token.Eval(context);
		}

		public string EvalText(INode token) {
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