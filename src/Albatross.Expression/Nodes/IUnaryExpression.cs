namespace Albatross.Expression.Nodes {
	public interface IUnaryExpression : IExpression, IHasPrecedence {
		string Operator { get; }
		IExpression? Operand { get; set; }
	}
}