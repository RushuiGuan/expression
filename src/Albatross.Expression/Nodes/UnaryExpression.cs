using Albatross.Expression.Exceptions;
using System;
using System.Text;

namespace Albatross.Expression.Nodes {
	public class UnaryExpression : IExpression {
		public UnaryExpression(string operatorName) {
			this.Name = operatorName;
		}
		public string Name { get; }
		public IExpression? Operand { get; set; }
		public IExpression RequiredOperand => Operand ?? throw new OperandException($"Unary expression '{this.Name}' is missing its operand");

		public string Text() {
			var sb = new StringBuilder();
			sb.Append(Name).Append(RequiredOperand.Text());
			return sb.ToString();
		}

		public virtual object Eval(Func<string, object> context) {
			throw new NotSupportedException();
		}
	}
}