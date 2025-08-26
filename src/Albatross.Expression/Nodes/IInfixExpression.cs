namespace Albatross.Expression.Nodes {
	/// <summary>
	/// Represents an infix binary operation expression (e.g., a + b, x > y).
	/// </summary>
	public interface IInfixExpression : IExpression, IHasPrecedence {
		/// <summary>
		/// The operator symbol used for this infix operation.
		/// </summary>
		string Operator { get; }
		
		/// <summary>
		/// The left operand of the infix operation.
		/// </summary>
		public IExpression? Left { get; set; }
		
		/// <summary>
		/// The right operand of the infix operation.
		/// </summary>
		public IExpression? Right { get; set; }
	}
}