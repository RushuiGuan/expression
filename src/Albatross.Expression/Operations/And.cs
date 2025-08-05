using System;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Operations {
	/// <summary>
	/// <para>Infix AND operation.</para>
	/// <para>Operand Count: 2</para>
	/// <list type="number">
	///		<listheader>
	///		<description>Operands</description>
	///		</listheader>
	///		<item><description>Operand1 : any</description></item>
	///		<item><description>Operand2 : any</description></item>
	/// </list>
	/// 
	/// <para>The input operands are converted to boolean.  See the <see cref="Albatross.Expression.Extensions.ConvertToBoolean(object)"/> method for the conversion logic</para>
	/// <para>Output Type: Boolean</para>
	/// <para>Usage: 3 > 2 and 2 > 1</para>
	/// <para>Precedence: 30</para>
	/// </summary>
	[ParserOperation(Group = "Logical")]
	public class And : InfixExpression {
		public And() : base("And", 30) { }

		public override object? Eval(Func<string, object> context) {
			var value = Operand1.Eval(context);
			if (!value.ConvertToBoolean()) {
				return false;
			} else {
				value = Operand2.Eval(context);
				return value.ConvertToBoolean();
			}
		}
	}
}