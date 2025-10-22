namespace Albatross.Expression.Infix {
	/// <summary>
	/// Infix expression that performs arithmetic subtraction between two numeric operands.
	/// Uses the "-" operator with precedence 100.
	/// </summary>
	public class Minus : InfixExpression {
		/// <summary>
		/// Initializes a new instance of the Minus class with operator "-" and precedence 100.
		/// </summary>
		public Minus() : base("-", 100) { }

		/// <summary>
		/// Performs subtraction by converting both operands to double and subtracting the right from the left.
		/// </summary>
		/// <param name="left">The left operand (minuend) to convert to double.</param>
		/// <param name="right">The right operand (subtrahend) to convert to double.</param>
		/// <returns>The result of left minus right as a double.</returns>
		/// <exception cref="System.FormatException">Thrown when either operand cannot be converted to double.</exception>
		protected override object Run(object left, object right)
			=> left.ConvertToDouble() - right.ConvertToDouble();
	}
}
