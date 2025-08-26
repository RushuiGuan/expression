namespace Albatross.Expression.Nodes {
	public interface IStringLiteral : IValueToken, IExpression {
		char Boundary { get; }
	}
}
