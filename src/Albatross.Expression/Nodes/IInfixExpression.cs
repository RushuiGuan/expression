namespace Albatross.Expression.Nodes {
	public interface IInfixExpression : IExpression, IHasPrecedence {
		string Operator { get; }
		public IExpression? Left { get; set; }
		public IExpression? Right { get; set; }
	}
}