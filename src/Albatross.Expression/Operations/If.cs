using System;
using Albatross.Expression.Nodes;


namespace Albatross.Expression.Operations {
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
	[ParserOperation]
	public class If : PrefixExpression {
		public If() : base("If", 3, 3) { }

		public override object Eval(Func<string, object> context) {
			object condition = this.GetValue(0, context);

			if (condition.ConvertToBoolean()) {
				return this.GetValue(1, context);
			} else {
				return this.GetValue(2, context);
			}
		}
	}
}