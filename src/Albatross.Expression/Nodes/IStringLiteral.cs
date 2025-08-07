namespace Albatross.Expression.Nodes {
	public interface IStringLiteral : IValueExpression {
		char Boundary { get; }
	}
}
