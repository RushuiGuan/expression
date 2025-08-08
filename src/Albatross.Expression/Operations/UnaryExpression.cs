using Albatross.Expression.Exceptions;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Albatross.Expression.Nodes {
	public class UnaryExpression : IUnaryExpression {
		public UnaryExpression(string operatorOperator) {
			this.Operator = operatorOperator;
		}
		public string Operator { get; }
		public IExpression? Operand { get; set; }
		public IExpression RequiredOperand => Operand ?? throw new OperandException($"Unary expression '{this.Operator}' is missing its operand");

		public string Text() {
			var sb = new StringBuilder();
			sb.Append(Operator).Append(RequiredOperand.Text());
			return sb.ToString();
		}

		public object Eval(Func<string, object> context) {
			var value = this.RequiredOperand.Eval(context);
			return Run(value);
		}

		public async Task<object> EvalAsync(Func<string, Task<object>> context) {
			var value = await RequiredOperand.EvalAsync(context);
			return Run(value);
		}

		public virtual object Run(object operand) {
			throw new NotSupportedException($"Unary operation '{Operator}' is not implemented.");
		}
	}
}