using Albatross.Expression.Nodes;

namespace Albatross.Expression.Unary {
	public class Negative : UnaryExpression {
		public Negative() : base("-", 250) { }

		protected override object Run(object operand) {
			return operand.ConvertToDouble() * -1;
		}
	}
}