namespace Albatross.Expression.InfixOperations {
	/// <summary>
	/// <para>Infix OR operation.</para>
	/// 
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
	/// <para>Usage: 3 > 2 or 2 > 1</para>
	/// <para>Precedance: 20</para>
	/// </summary>
	public class Or : InfixExpression {
		public Or() : base("or", 20) { }

		public override object Run(object left, object right)
			=> left.ConvertToBoolean() || right.ConvertToBoolean();
	}
}