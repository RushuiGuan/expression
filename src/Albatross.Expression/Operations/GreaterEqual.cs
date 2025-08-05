namespace Albatross.Expression.Operations {
	/// <summary>
	/// <para>Infix GreaterEqual operation.</para>
	/// <para>Operand Count: 2</para>
	/// <list type="number">
	///		<listheader>
	///		<description>Operands</description>
	///		</listheader>
	///		<item><description>Operand1 : any</description></item>
	///		<item><description>Operand2 : any</description></item>
	/// </list>
	/// 
	/// <para>Output Type: Boolean</para>
	/// <para>Usage: 3 >= 2</para>
	/// <para>Precedance: 50</para>
	/// </summary>
	[ParserOperation]
	public class GreaterEqual : ComparisonInfixOperation {
		
		public override string Operator { get { return ">="; } }
		public override int Precedence { get { return 50; } }

		public override bool interpret(int comparisonResult) {
			return comparisonResult >= 0;
		}
	}
}
