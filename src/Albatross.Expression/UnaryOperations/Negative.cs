using Albatross.Expression.Nodes;

namespace Albatross.Expression.UnaryOperations {
	public class Negative : UnaryExpression {
		public Negative() : base("-") { }

		public override object Run(object operand) {
			return operand.ConvertToDouble() * -1;
		}
	}
}