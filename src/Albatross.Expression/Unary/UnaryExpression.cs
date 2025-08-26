using Albatross.Expression.Exceptions;
using Albatross.Expression.Nodes;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Albatross.Expression.Unary {
	public class UnaryExpression : IUnaryExpression {
		public UnaryExpression(string operatorOperator, int precedence) {
			Operator = operatorOperator;
			Precedence = precedence;
		}

		public int Precedence { get; }
		public string Operator { get; }
		public string Token => Operator;
		public IExpression? Operand { get; set; }
		public IExpression RequiredOperand => Operand ?? throw new OperandException($"Unary expression '{Operator}' is missing its operand");

		public string Text() {
			var sb = new StringBuilder();
			sb.Append(Operator).Append(RequiredOperand.Text());
			return sb.ToString();
		}

		public object Eval(Func<string, object> context) {
			var value = RequiredOperand.Eval(context);
			return Run(value);
		}

		public async Task<object> EvalAsync(Func<string, Task<object>> context) {
			var value = await RequiredOperand.EvalAsync(context);
			return Run(value);
		}

		protected virtual object Run(object operand) {
			throw new NotSupportedException($"Unary operation '{Operator}' is not implemented.");
		}
	}
}