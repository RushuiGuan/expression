namespace Albatross.Expression.Nodes {
	/// <summary>
	/// Represents a string literal token with boundary character information.
	/// </summary>
	public interface IStringLiteral : IValueToken, IExpression {
		/// <summary>
		/// The boundary character (quote type) that delimits this string literal.
		/// </summary>
		char Boundary { get; }
	}
}
