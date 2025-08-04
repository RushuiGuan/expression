using System.Linq;
using System;
using System.Collections.Generic;
using Albatross.Expression.Exceptions;
using Albatross.Expression.Tokens;
using System.Diagnostics;

namespace Albatross.Expression {
	/// <summary>
	/// An immutable implementation of the <see cref="Albatross.Expression.IParser"/> interface.
	/// </summary>
	public class Parser : IParser {
		public IToken VariableToken() {
			return variableToken.Clone();
		}

		public IStringLiteralToken StringLiteralToken() {
			return (IStringLiteralToken)stringLiteralToken.Clone();
		}

		readonly List<PrefixOperationToken> prefixOperationTokens = new List<PrefixOperationToken>();
		readonly List<InfixOperationToken> infixOperationTokens = new List<InfixOperationToken>();
		IToken variableToken;
		IStringLiteralToken stringLiteralToken;

		public Parser(IEnumerable<IToken> operations, IVariableToken variableToken, IStringLiteralToken stringLiteralToken) {
			prefixOperationTokens.Clear();
			infixOperationTokens.Clear();

			this.variableToken = variableToken;
			this.stringLiteralToken = stringLiteralToken;
			foreach (var item in operations) {
				Add(item);
			}
		}

		IParser Add(IToken token) {
			if (token is PrefixOperationToken) {
				prefixOperationTokens.Add((PrefixOperationToken)token);
			} else if (token is InfixOperationToken) {
				infixOperationTokens.Add((InfixOperationToken)token);
			} else {
				throw new NotSupportedException();
			}

			return this;
		}

		//parse an expression and produce queue of tokens
		//the expression is parse from left to right
		public Queue<IToken> Tokenize(string expression) {
			if (string.IsNullOrEmpty(expression)) {
				throw new ArgumentException();
			}

			Queue<IToken> tokens = new Queue<IToken>();
			int start = 0, next;
			IToken? last;
			IEnumerable<IToken>? list;
			bool found;
			while (start < expression.Length) {
				found = false;
				last = tokens.Count == 0 ? null : tokens.Last();
				list = null;
				if (last == null || last == ControlToken.Comma || ( last is PrefixOperationToken && ( (PrefixOperationToken)last ).Symbolic ) || last is InfixOperationToken) {
					list = new IToken[] { new BooleanLiteralToken(), VariableToken(), StringLiteralToken(), new NumericLiteralToken(), ControlToken.LeftParenthesis }.Union(prefixOperationTokens);
				} else if (last == ControlToken.LeftParenthesis) {
					list = new IToken[] { VariableToken(), StringLiteralToken(), new NumericLiteralToken(), ControlToken.LeftParenthesis, ControlToken.RightParenthesis }.Union(prefixOperationTokens);
				} else if (last == ControlToken.RightParenthesis || last is IOperandToken) {
					list = new IToken[] { ControlToken.Comma, ControlToken.RightParenthesis }.Union(infixOperationTokens);
				} else if (last is PrefixOperationToken && !( (PrefixOperationToken)last ).Symbolic) {
					list = new IToken[] { ControlToken.LeftParenthesis };
				}

				Debug.Assert(list != null, "Forgot to check an previous operation");
				foreach (IToken token in list) {
					if (token.Match(expression, start, out next)) {
						found = true;
						start = next;
						if (token is PrefixOperationToken || token is InfixOperationToken) {
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

		public Stack<IToken> BuildStack(Queue<IToken> queue) {
			IToken token;
			Stack<IToken> postfix = new Stack<IToken>();
			Stack<IToken> stack = new Stack<IToken>();

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
				if (token is IOperandToken) {
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
				} else if (token is PrefixOperationToken) {
					stack.Push(token);
					postfix.Push(ControlToken.FuncParamStart);
				} else if (token is InfixOperationToken) {
					if (stack.Count == 0 || stack.Peek() == ControlToken.LeftParenthesis) {
						stack.Push(token);
					} else {
						InfixOperationToken infix = (InfixOperationToken)token;
						while (stack.Count > 0
						       && stack.Peek() != ControlToken.LeftParenthesis
						       && ( stack.Peek() is PrefixOperationToken
						            || stack.Peek() is InfixOperationToken
						            && infix.Precedence <= ( (InfixOperationToken)stack.Peek() ).Precedence )) {
							postfix.Push(stack.Pop());
						}

						stack.Push(token);
					}
				}
			}

			while (stack.Count > 0) {
				token = stack.Pop();
				if (token == ControlToken.LeftParenthesis) {
					throw new TokenParsingException("unbalance paranthesis");
				} else {
					postfix.Push(token);
				}
			}

			return postfix;
		}

		public IToken CreateTree(Stack<IToken> postfix) {
			postfix = Reverse(postfix);
			Stack<IToken> stack = new Stack<IToken>();
			IToken token;
			while (postfix.Count > 0) {
				token = postfix.Pop();
				if (token is IOperandToken || token == ControlToken.FuncParamStart) {
					stack.Push(token);
				} else if (token is InfixOperationToken) {
					InfixOperationToken infixOp = (InfixOperationToken)token;
					infixOp.Operand2 = stack.Pop();
					infixOp.Operand1 = stack.Pop();
					stack.Push(infixOp);
				} else if (token is PrefixOperationToken) {
					PrefixOperationToken prefixOp = (PrefixOperationToken)token;
					for (IToken t = stack.Pop(); t != ControlToken.FuncParamStart; t = stack.Pop()) {
						prefixOp.Operands.Insert(0, t);
					}

					stack.Push(prefixOp);
				}
			}

			return stack.Pop();
		}

		public object? Eval(IToken token, Func<string, object> context) {
			return token.EvalValue(context);
		}

		public string EvalText(IToken token, string format) {
			return token.EvalText(format);
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