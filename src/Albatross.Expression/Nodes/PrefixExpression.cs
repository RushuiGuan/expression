using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Exceptions;
using Albatross.Expression.ExpressionFactory;

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
			var sb = new StringBuilder();
			sb.Append(Name);
			sb.Append(ControlTokenFactory.LeftParenthesis.Token);
			foreach (var token in Operands) {
				sb.Append(token.Text());
				if (token != Operands.Last()) {
					sb.Append(ControlTokenFactory.Comma.ToString()).Append(' ');
				}
			}
			sb.Append(ControlTokenFactory.RightParenthesis.Token);
			return sb.ToString();
		}

		public virtual object Eval(Func<string, object> context) {
			throw new NotSupportedException();
		}

		protected void ValidateOperands() {
			if (Operands.Count < MinOperandCount) {
				throw new OperandException($"Prefix operation '{Name}' requires at least {MinOperandCount} operands, but received {Operands.Count}.");
			}
			if (Operands.Count > MaxOperandCount) {
				throw new OperandException($"Prefix operation '{Name}' allows at most {MaxOperandCount} operands, but received {Operands.Count}.");
			}
		}
		
		protected List<Object?> GetRequiredOperandValues(Func<string, object> context) {
			var list = new List<object?>();
			foreach (var token in Operands) {
				var value = token.Eval(context);
				list.Add(value);
			}
			if (list.Count < MinOperandCount || list.Count > MaxOperandCount) { throw new OperandException(Name); }
			return list;
		}
	}
}