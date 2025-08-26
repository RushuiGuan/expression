namespace Albatross.Expression.Infix {
	/// <summary>
	/// Represents the equality comparison operator that checks if two values are equal.
	/// </summary>
	public class Equal : ComparisonInfixOperation {
		/// <summary>
		/// Initializes a new instance of the <see cref="Equal"/> class.
		/// </summary>
		public Equal() : base("=", 50) { }

		public override bool Interpret(int comparisonResult) {
			return comparisonResult == 0;
		}
	}
}
