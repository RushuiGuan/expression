using Albatross.Expression.Nodes;

namespace Albatross.Expression.Unary {
	/// <summary>
	/// Represents the unary negation operator that converts positive numbers to negative and vice versa.
	/// </summary>
	public class Negative : UnaryExpression {
		/// <summary>
		/// Initializes a new instance of the <see cref="Negative"/> class.
		/// </summary>
		public Negative() : base("-", 250) { }

		public override object Run(object operand) {
			return operand.ConvertToDouble() * -1;
		}
	}
}