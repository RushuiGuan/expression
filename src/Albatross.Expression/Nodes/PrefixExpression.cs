using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Exceptions;
using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace Albatross.Expression.Nodes {
	public class PrefixExpression : IExpression {
		public PrefixExpression(string name, int minOperandCount, int maxOperandCount) {
			Name = name;
			MinOperandCount = minOperandCount;
			MaxOperandCount = maxOperandCount;
		}

		public string Name { get; }
		public int MinOperandCount { get; }
		public int MaxOperandCount { get; }

		public List<IExpression> Operands { get; private set; } = new();

		public string Text() {
			if (Operands.Count < MinOperandCount || Operands.Count > MaxOperandCount) {
				throw new OperandException(Name);
			}
			var sb = new StringBuilder();
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
			return sb.ToString();
		}

		public virtual object? Eval(Func<string, object> context) {
			throw new NotSupportedException();
		}

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
				return Array.Empty<object>();
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
			foreach (var token in Operands) {
				var value = token.Eval(context);
				list.Add(value);
			}
			if (list.Count < MinOperandCount || list.Count > MaxOperandCount) { throw new OperandException(Name); }
			return list;
		}

		//return operands of the same type
		protected List<Object?> GetOperands(Func<string, object> context, out Type? firstType) {
			var list = new List<object?>();
			firstType = null;
			foreach (var token in Operands) {
				var value = token.Eval(context);
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
			foreach (var token in Operands) {
				var value = token.Eval(context);
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
}