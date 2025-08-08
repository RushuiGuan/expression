namespace Albatross.Expression.Nodes {
	public interface IInfixExpression : IExpression {
		string Operator { get; }
		int Precedence { get; }
		public IExpression? Left { get; set; }
		public IExpression? Right { get; set; }
	}
}