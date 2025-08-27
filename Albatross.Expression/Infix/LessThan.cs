namespace Albatross.Expression.Infix {
	/// <summary>
	/// Infix expression that performs less-than comparison between two operands.
	/// Uses the "&lt;" operator with precedence 50.
	/// </summary>
	public class LessThan : ComparisonInfixOperation {
		/// <summary>
		/// Initializes a new instance of the LessThan class with operator "&lt;" and precedence 50.
		/// </summary>
		public LessThan() : base("<", 50) { }

		/// <summary>
		/// Interprets the comparison result to determine if the left operand is less than the right operand.
		/// </summary>
		/// <param name="comparisonResult">The result from comparing the operands (-1, 0, or 1).</param>
		/// <returns>true if the left operand is less than the right operand; otherwise, false.</returns>
		public override bool Interpret(int comparisonResult) {
			return comparisonResult < 0;
		}
	}
}
