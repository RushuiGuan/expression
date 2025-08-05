namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class LessEqual : ComparisonInfixOperation {
		public override string Operator { get { return "<="; } }
		public override int Precedence { get { return 50; } }

		public override bool interpret(int comparisonResult) {
			return comparisonResult <= 0;
		}
	}
}
