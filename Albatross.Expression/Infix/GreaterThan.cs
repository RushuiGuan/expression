using System.Diagnostics.CodeAnalysis;

namespace Albatross.Expression.Infix {
	/// <summary>
	/// <para>Infix GreaterThan operation.</para>
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
	/// <para>Usage: 3 > 2</para>
	/// <para>Precedance: 50</para>
	/// </summary>
	public class GreaterThan : ComparisonInfixOperation {
		public GreaterThan() : base(">", 50) { }

		public override bool Interpret(int comparisonResult) {
			return comparisonResult > 0;
		}
	}
}
