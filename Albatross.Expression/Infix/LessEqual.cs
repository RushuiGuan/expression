namespace Albatross.Expression.Infix {
	/// <summary>
	/// Infix expression that performs less-than-or-equal comparison between two operands.
	/// Uses the "&lt;=" operator with precedence 50.
	/// </summary>
	public class LessEqual : ComparisonInfixOperation {
		/// <summary>
		/// Initializes a new instance of the LessEqual class with operator "&lt;=" and precedence 50.
		/// </summary>
		public LessEqual() : base("<=", 50) { }

		/// <summary>
		/// Interprets the comparison result to determine if the left operand is less than or equal to the right operand.
		/// </summary>
		/// <param name="comparisonResult">The result from comparing the operands (-1, 0, or 1).</param>
		/// <returns>true if the left operand is less than or equal to the right operand; otherwise, false.</returns>
		public override bool Interpret(int comparisonResult) {
			return comparisonResult <= 0;
		}
	}
}
