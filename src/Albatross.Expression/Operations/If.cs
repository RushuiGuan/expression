using System;
using System.Linq;
using Albatross.Expression.Nodes;


namespace Albatross.Expression.Operations {
	/// <summary>
	/// <para>Prefix if operation</para>
	/// <para>Operand Count: 2 or 3</para>
	/// <list type="number">
	///		<listheader>
	///		<description>Operands</description>
	///		</listheader>
	///		<item><description>condition: any</description></item>
	///		<item><description>result when true: any</description></item>
	///		<item><description>result when false, if omitted, will be default to null: any</description></item>
	/// </list>
	/// 
	/// <para>Output Type: any</para>
	/// <para>Usage: if( 3 > 2, "OK", "No")</para>
	/// </summary>
	[ParserOperation]
	public class If : PrefixExpression {
		public If() : base("If", 2, 3) { }

		public override object? Eval(Func<string, object> context) {
			ValidateOperands();
			object condition = this.GetRequiredValue(0, context);

			if (condition.ConvertToBoolean()) {
				return Operands[1].Eval(context);
			} else {
				if (Operands.Count >= 3) {
					return Operands[2].Eval(context);
				} else {
					return null;
				}
			}
		}
	}
}
