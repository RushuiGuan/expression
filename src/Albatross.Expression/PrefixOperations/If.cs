using System.Collections.Generic;


namespace Albatross.Expression.PrefixOperations {
	/// <summary>
	/// <para>Prefix if operation</para>
	/// <para>Operand Count: 3</para>
	/// <list type="number">
	///		<listheader>
	///		<description>Operands</description>
	///		</listheader>
	///		<item><description>condition: any</description></item>
	///		<item><description>result when true: any</description></item>
	///		<item><description>result when false: any</description></item>
	/// </list>
	/// 
	/// <para>Output Type: any</para>
	/// <para>Usage: if( 3 > 2, "OK", "No")</para>
	/// </summary>
	public class If : PrefixExpression {
		public If() : base("If", 3, 3) { }


		public override object Run(List<object> operands) {
			var condition = operands[0].ConvertToBoolean();
			if (condition) {
				return operands[1];
			} else {
				return operands[2];
			}
		}
	}
}