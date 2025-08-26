using Albatross.Expression.Nodes;

namespace Albatross.Expression.Infix {
	public class Minus : InfixExpression {
		public Minus() : base("-", 100) { }

		protected override object Run(object left, object right)
			=> left.ConvertToDouble() - right.ConvertToDouble();
	}
}
