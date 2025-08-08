using System.Linq;
using System;
using System.Collections.Generic;
using Albatross.Expression.Exceptions;
using Albatross.Expression.Nodes;
using System.Diagnostics;
using Albatross.Expression.ExpressionFactory;
using Albatross.Expression.UnaryOperations;

namespace Albatross.Expression.ExpressionFactory {
	/// <summary>
	/// An immutable implementation of the <see cref="Albatross.Expression.IParser"/> interface.
	/// </summary>
	public class Parser : IParser {
		private readonly IReadOnlyList<IExpressionFactory<IToken>> other_left;
		private readonly IReadOnlyList<IExpressionFactory<IToken>> other_left_right;
		private readonly IReadOnlyList<IExpressionFactory<IToken>> infix_comma_right;
		private readonly IReadOnlyList<IExpressionFactory<IToken>> left_parenthesis_only;

		public Parser(IEnumerable<IExpressionFactory<IToken>> factories) {
			var infix = new List<IExpressionFactory<IToken>>();
			var others = new List<IExpressionFactory<IToken>>();
			foreach (var factory in factories) {
				if (factory is IExpressionFactory<IInfixExpression> infixFactory) {
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
		public Queue<IToken> Tokenize(string expression) {
			var tokens = new Queue<IToken>();
			int start = 0;
			while (start < expression.Length) {
				bool found = false;
				var last = tokens.LastOrDefault();
				IEnumerable<IExpressionFactory<IToken>>? factories = null;
				if (last == null || last.IsComma() || last is UnaryExpression || last is IInfixExpression) {
					factories = other_left;
				} else if (last.IsLeftParenthesis()) {
					factories = other_left_right;
				} else if (last.IsRightParenthesis() || last is IExpression) {
					factories = infix_comma_right;
				} else if (last is IPrefixExpression) {
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

		public Stack<IToken> BuildPostfixStack(Queue<IToken> queue) {
			IToken token;
			var postfix = new Stack<IToken>();
			var stack = new Stack<IToken>();

			while (queue.Count > 0) {
				token = queue.Dequeue();
				if (token.IsComma()) {
					//pop stack to postfix until we see left parenthesis
					while (stack.Count > 0 && stack.Peek().IsLeftParenthesis(false)) {
						postfix.Push(stack.Pop());
					}

					if (stack.Count == 0) {
						throw new StackException("misplace comma or missing left parenthesis");
					} else {
						continue;
					}
				}

				// if it is an operand, put it on the postfix stack
				if (token is IValueExpression expression) {
					postfix.Push(expression);
				}

				if (token.IsLeftParenthesis()) {
					stack.Push(token);
				} else if (token.IsRightParenthesis()) {
					while (stack.Count > 0 && stack.Peek().IsLeftParenthesis(false)) {
						postfix.Push(stack.Pop());
					}

					if (stack.Count == 0) {
						throw new StackException("missing left parenthesis");
					} else {
						// pop the left parenthesis
						stack.Pop();
					}
				} else if (token is IPrefixExpression) {
					stack.Push(token);
					postfix.Push(ControlTokenFactory.FuncParamStart.Token);
				} else if (token is IInfixExpression infix) {
					if (stack.Count == 0 || stack.Peek().IsLeftParenthesis()) {
						stack.Push(token);
					} else {
						while (stack.Count > 0
							   && stack.Peek().IsLeftParenthesis(false)
							   && (stack.Peek() is IPrefixExpression
									|| stack.Peek() is IInfixExpression
									&& infix.Precedence <= ((IInfixExpression)stack.Peek()).Precedence)) {
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

		public IExpression CreateTree(Stack<IToken> postfix) {
			var reversed = Reverse(postfix);
			var stack = new Stack<IToken>();
			while (reversed.Count > 0) {
				var token = reversed.Pop();
				if (token is IExpression || token.IsFuncParamStart()) {
					stack.Push(token);
				} else if (token is IInfixExpression infix) {
					infix.Right = stack.Pop() as IExpression ?? throw new StackException("misplaced control token as infix right operand");
					infix.Left = stack.Pop() as IExpression ?? throw new StackException("misplaced control token as infix left operand");
					stack.Push(infix);
				} else if (token is IPrefixExpression prefix) {
					for (IToken t = stack.Pop(); t.IsFuncParamStart(false); t = stack.Pop()) {
						// TODO: optimize this insert to avoid shifting
						prefix.Operands.Insert(0, t as IExpression ?? throw new StackException("misplaced control token as prefix operand"));
					}
					stack.Push(prefix);
				}
			}
			return stack.Pop() as IExpression ?? throw new StackException("misplace control token as expression root");
		}

		static Stack<T> Reverse<T>(Stack<T> src) {
			var dst = new Stack<T>();
			while (src.Count > 0) {
				dst.Push(src.Pop());
			}
			return dst;
		}
	}
}