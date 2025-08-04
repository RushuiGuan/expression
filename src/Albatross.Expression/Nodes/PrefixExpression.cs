using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Exceptions;
using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace Albatross.Expression.Nodes {
	public abstract class PrefixExpression : IExpression {
		public abstract string Name { get; }
		public abstract bool Symbolic { get; }
		public abstract int MinOperandCount { get; }
		public abstract int MaxOperandCount { get; }

		public List<IExpression> Operands { get; private set; } = new();

		public virtual string Text() {
			if (Operands.Count < MinOperandCount || Operands.Count > MaxOperandCount) {
				throw new OperandException(Name);
			}
			var sb = new StringBuilder();
			if (Symbolic) {
				sb.Append(Name);
				if (Operands.Count == 0) {
					sb.Append("[Missing]");
				} else {
					sb.Append(Operands.First().Text());
				}
			} else {
				sb.Append(Name);
				sb.Append(ControlToken.LeftParenthesis);
				foreach (var token in Operands) {
					sb.Append(token.Text());
					if (token != Operands.Last()) {
						sb.Append(ControlToken.Comma.ToString()).Append(' ');
					}
				}
				//sb.Append(string.Join(ControlToken.Comma.ToString(), from token in Operands select token.EvalText(format)));
				sb.Append(ControlToken.RightParenthesis);
			}
			return sb.ToString();
		}

		public abstract object? Eval(Func<string, object> context);

		protected void ValidateOperands() {
			if (Operands.Count() < MinOperandCount || Operands.Count() > MaxOperandCount) {
				throw new OperandException(Name);
			}
		}

		//if the operand count = 1 and it is an array, return the array
		//otherwise return normal operand values
		protected IEnumerable GetParamsOperands(Func<string, object> context, out Type? firstType) {
			firstType = null;
			if (Operands.Count == 0) {
				return new object[0];
			} else if (Operands.Count == 1) {
				var op1 = Operands.First().Eval(context);
				if (op1 is IEnumerable) {
					foreach (object obj in (IEnumerable)op1) {
						if (obj != null) {
							firstType = obj.GetType();
							break;
						}
					}
					return (IEnumerable)op1;
				} else {
					if (op1 != null) { firstType = op1.GetType(); }
					return new object[] { op1 };
				}
			} else {
				return GetOperands(context, out firstType);
			}
		}

		protected List<Object?> GetOperands(Func<string, object> context) {
			var list = new List<object?>();
			object? value;
			foreach (var token in Operands) {
				value = token.Eval(context);
				list.Add(value);
			}
			if (list.Count < MinOperandCount || list.Count > MaxOperandCount) { throw new OperandException(Name); }
			return list;
		}

		//return operands of the same type
		protected List<Object?> GetOperands(Func<string, object> context, out Type? firstType) {
			var list = new List<object?>();
			firstType = null;
			object? value;
			foreach (var token in Operands) {
				value = token.Eval(context);
				list.Add(value);
				if (firstType == null) {
					if (value != null) {
						firstType = value.GetType();
					}
				}
			}
			if (list.Count < MinOperandCount || list.Count > MaxOperandCount) { throw new OperandException(Name); }
			return list;
		}

		protected List<T?> GetOperands<T>(Func<string, object> context) {
			var list = new List<T?>();
			object? value;
			foreach (var token in Operands) {
				value = token.Eval(context);
				if (value != null && !( value is T )) {
					throw new UnexpectedTypeException(typeof(T), value.GetType());
				} else if (value == null) {
					list.Add(default(T));
				} else {
					list.Add((T)value);
				}
			}
			if (list.Count < MinOperandCount || list.Count > MaxOperandCount) { throw new OperandException(Name); }
			return list;
		}
	}

	public class PrefixExpressionFactory<T> : IExpressionFactory<T> where T : PrefixExpression, new() {
		public bool TryParse(string expression, int start, out int next, [NotNullWhen(true)] out T? node) {
			node = null;
			next = expression.Length;
			if (start < expression.Length) {
				while (start < expression.Length && char.IsWhiteSpace(expression[start])) {
					start++;
				}
				var t = new T();
				if (expression.IndexOf(t.Name, start, StringComparison.InvariantCultureIgnoreCase) == start) {
					if (t.Symbolic) {
						next = start + t.Name.Length;
						node = t;
						return true;
					} else {
						char c;
						//look for a left Parenthesis, but don't consume it
						for (int i = start + t.Name.Length; i < expression.Length; i++) {
							c = expression[i];
							if (char.IsWhiteSpace(c)) {
								continue;
							} else if (c == Token.LeftParenthesis) {
								next = start + t.Name.Length;
								node = t;
								return true;
							} else {
								return false;
							}
						}
					}
				}
			}
			return false;
		}
	}
}