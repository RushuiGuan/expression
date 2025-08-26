namespace Albatross.Expression.Nodes {
	/// <summary>
	/// Represents a unary operation expression that operates on a single operand (e.g., -x, +y).
	/// </summary>
	public interface IUnaryExpression : IExpression, IHasPrecedence {
		/// <summary>
		/// The operator symbol used for this unary operation.
		/// </summary>
		string Operator { get; }
		
		/// <summary>
		/// The operand that this unary operation applies to.
		/// </summary>
		IExpression? Operand { get; set; }
	}
}