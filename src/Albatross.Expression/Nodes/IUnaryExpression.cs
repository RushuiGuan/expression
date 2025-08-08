namespace Albatross.Expression.Nodes {
	public interface IUnaryExpression : IExpression {
		string Operator { get; }
		IExpression? Operand { get; set; }
	}
}