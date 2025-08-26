namespace Albatross.Expression.Infix {
	/// <summary>
	/// Represents the logical AND operator that returns true when both operands are true.
	/// </summary>
	public class And : InfixExpression {
		/// <summary>
		/// Initializes a new instance of the <see cref="And"/> class.
		/// </summary>
		public And() : base("and", 30) { }

		protected override object Run(object left, object right)
			=> left.ConvertToBoolean() && right.ConvertToBoolean();
	}
}