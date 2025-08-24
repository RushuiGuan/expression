using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Exceptions;
using Albatross.Expression.ExpressionFactory;
using Albatross.Expression.Nodes;
using System.Threading.Tasks;

namespace Albatross.Expression.PrefixOperations {
	public class PrefixExpression : IPrefixExpression {
		public PrefixExpression(string name, int minOperandCount, int maxOperandCount) {
			Name = name;
			MinOperandCount = minOperandCount;
			MaxOperandCount = maxOperandCount;
		}

		public string Name { get; }
		public string Token => Name;
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

		public object Eval(Func<string, object> context) {
			ValidateOperands();
			var values = this.GetValues(context);
			return Run(values);
		}

		public async Task<object> EvalAsync(Func<string, Task<object>> context) {
			ValidateOperands();
			var values = await this.GetValuesAsync(context);
			return Run(values);
		}

		public virtual object Run(List<object> operands) {
			throw new NotSupportedException($"Prefix expression {this.Name} is not supported");
		}

		protected void ValidateOperands() {
			if (Operands.Count < MinOperandCount) {
				throw new OperandException($"Prefix operation '{Name}' requires at least {MinOperandCount} operands, but received {Operands.Count}.");
			}
			if (Operands.Count > MaxOperandCount) {
				throw new OperandException($"Prefix operation '{Name}' allows at most {MaxOperandCount} operands, but received {Operands.Count}.");
			}
		}
	}
}