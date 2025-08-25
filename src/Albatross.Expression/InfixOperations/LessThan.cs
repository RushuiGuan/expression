namespace Albatross.Expression.InfixOperations {
	public class LessThan : ComparisonInfixOperation {
		public LessThan() : base("<", 50) { }

		public override bool Interpret(int comparisonResult) {
			return comparisonResult < 0;
		}
	}
}
