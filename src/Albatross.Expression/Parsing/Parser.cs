using System.Linq;
using System;
using System.Collections.Generic;
using Albatross.Expression.Exceptions;
using Albatross.Expression.Infix;
using Albatross.Expression.Nodes;
using System.Diagnostics;
using Albatross.Expression.Unary;

namespace Albatross.Expression.Parsing {
	/// <summary>
	/// An immutable implementation of the <see cref="Albatross.Expression.IParser"/> interface.
	/// </summary>
	public class Parser : IParser {
		private readonly IExpressionFactory<IToken>[] infixCommaRight;
		private readonly IExpressionFactory<IToken>[] prefixUnaryValueLeft;
		private readonly IExpressionFactory<IToken>[] left;
		private readonly IExpressionFactory<IToken>[] prefixUnaryValueLeftRight;

		public Parser(IEnumerable<IExpressionFactory<IToken>> factories) {
			var infix = new List<IExpressionFactory<IToken>>();
			var prefix = new List<IExpressionFactory<IToken>>();
			var value = new List<IExpressionFactory<IToken>>();
			var unary = new List<IExpressionFactory<IToken>>();
			foreach (var factory in factories) {
				if (factory is IExpressionFactory<IInfixExpression>) {
					infix.Add(factory);
				} else if (factory is IExpressionFactory<IPrefixExpression>) {
					prefix.Add(factory);
				} else if (factory is IExpressionFactory<IValueToken>) {
					value.Add(factory);
				} else if (factory is IExpressionFactory<UnaryExpression> unaryFactory) {
					unary.Add(unaryFactory);
				} else {
					throw new ArgumentException("Unknown factory type: " + factory.GetType().FullName);
				}
			}
			this.left = [ControlTokenFactory.LeftParenthesis];
			this.prefixUnaryValueLeft = prefix.Union(unary).Union(value).Union(this.left).ToArray();
			this.prefixUnaryValueLeftRight = prefix.Union(unary).Union(value).Union(this.left).Union([ControlTokenFactory.RightParenthesis]).ToArray();
			this.infixCommaRight = infix.Union([ControlTokenFactory.Comma, ControlTokenFactory.RightParenthesis]).ToArray();
		}

		//parse an expression and produce queue of tokens
		//the expression is parse from left to right
		public Queue<IToken> Tokenize(string expression) {
			var tokens = new Queue<IToken>();
			int start = 0;
			IToken? last = null;
			while (start < expression.Length) {
				bool found = false;
				IEnumerable<IExpressionFactory<IToken>>? factories = null;
				/*
				if (last == null || last == ControlToken.Comma || (last is PrefixOperationToken && ((PrefixOperationToken)last).Symbolic) || last is InfixOperationToken) {
					list = new IToken[] { new BooleanLiteralToken(), VariableToken(), StringLiteralToken(), new NumericLiteralToken(), ControlToken.LeftParenthesis }.Union(prefixOperationTokens);
				} else if (last == ControlToken.LeftParenthesis) {
					list = new IToken[] { new BooleanLiteralToken(), VariableToken(), StringLiteralToken(), new NumericLiteralToken(), ControlToken.LeftParenthesis, ControlToken.RightParenthesis }.Union(prefixOperationTokens);
				} else if (last == ControlToken.RightParenthesis || last is IOperandToken) {
					list = new IToken[] { ControlToken.Comma, ControlToken.RightParenthesis }.Union(infixOperationTokens);
				} else if (last is PrefixOperationToken && !((PrefixOperationToken)last).Symbolic) {
					list = new IToken[] { ControlToken.LeftParenthesis };
				}
				*/
				if (last == null || last.IsComma() || last is IUnaryExpression || last is IInfixExpression) {
					factories = this.prefixUnaryValueLeft;
				} else if (last.IsLeftParenthesis()) {
					factories = this.prefixUnaryValueLeftRight;
				} else if (last.IsRightParenthesis() || last is IValueToken) {
					factories = this.infixCommaRight;
				} else if (last is IPrefixExpression) {
					factories = this.left;
				} else {
					Debug.Fail("Forgot to check an previous operation");
				}
				foreach (var factory in factories) {
					var node = factory.Parse(expression, start, out var next);
					if (node != null) {
						found = true;
						start = next;
						tokens.Enqueue(node);
						last = node;
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
				if (token is IValueToken valueToken) {
					postfix.Push(valueToken);
				} else if (token.IsLeftParenthesis()) {
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
				} else if (token is IHasPrecedence current) {
					while (stack.Count > 0) {
						var peeked = stack.Peek();
						if (peeked is IPrefixExpression || 
						    peeked is IHasPrecedence previous 
						    && previous.Precedence >= current.Precedence 
						    && !(peeked is Power && current is Power)	// power is right associative
						    && !(current is IUnaryExpression)	// unary is right associative.  if a unary operator is on the right side, it has higher precedence always.  for example: a ^ -b.  The - unary has higher precedence than ^ in this case.
						) {
							postfix.Push(stack.Pop());
						} else {
							break;
						}
					}
					stack.Push(token);
					if(token is IUnaryExpression) {
						postfix.Push(ControlTokenFactory.FuncParamStart.Token);
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
				if (token is IValueToken || token.IsFuncParamStart()) {
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