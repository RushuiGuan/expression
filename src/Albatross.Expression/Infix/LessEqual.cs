namespace Albatross.Expression.Infix {
	public class LessEqual : ComparisonInfixOperation {
		public LessEqual() : base("<=", 50) { }

		public override bool Interpret(int comparisonResult) {
			return comparisonResult <= 0;
		}
	}
}
