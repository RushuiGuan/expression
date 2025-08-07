using Albatross.Expression.Exceptions;
using System;
using System.Text;

namespace Albatross.Expression.Nodes {
	public class UnaryExpression : IExpression {
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

		public virtual object Eval(Func<string, object> context) {
			throw new NotSupportedException();
		}
	}
}