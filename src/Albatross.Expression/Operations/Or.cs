using System;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Operations {
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
	[ParserOperation]
	public class Or : InfixExpression {
		public Or() : base("Or", 20) { }

		public override object Eval(Func<string, object> context) {
			if (RequiredLeft.Eval(context).ConvertToBoolean()) {
				return true;
			} else {
				return RequiredRight.Eval(context).ConvertToBoolean();
			}
		}
	}
}