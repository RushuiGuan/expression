using Albatross.Expression.Nodes;

namespace Albatross.Expression.InfixOperations {
	[ParserOperation]
	public class Minus : InfixExpression {
		public Minus() : base("-", 100) { }

		public override object Run(object left, object right)
			=> left.ConvertToDouble() - right.ConvertToDouble();
	}
}
