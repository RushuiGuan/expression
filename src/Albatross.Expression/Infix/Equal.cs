namespace Albatross.Expression.Infix {
	/// <summary>
	/// <para>Infix operation that perform an equal check</para>
	/// <para>Operand Count: 2</para>
	/// <list type="number">
	///		<listheader>
	///		<description>Operands</description>
	///		</listheader>
	///		<item><description>Operrand1 : double</description></item>
	///		<item><description>Operrand2 : double</description></item>
	/// </list>
	/// <para>Output Type: double</para>
	/// </summary>
	public class Equal : ComparisonInfixOperation {
		public Equal() : base("=", 50) { }

		public override bool Interpret(int comparisonResult) {
			return comparisonResult == 0;
		}
	}
}
