using System;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Operations {
	/// <summary>
	/// <para>Infix operation that perform an power operation</para>
	/// <para>Operand Count: 2</para>
	/// <list type="number">
	///		<listheader>
	///		<description>Operands</description>
	///		</listheader>
	///		<item><description>base : double</description></item>
	///		<item><description>operand : double</description></item>
	/// </list>
	/// <para>Output Type: double</para>
	/// </summary>
	[ParserOperation]
	public class Power : InfixExpression {
		public Power() : base("^", 300) { }

		public override object Eval(Func<string, object> context) {
			var a = RequiredLeft.Eval(context).ConvertToDouble();
			var b = RequiredRight.Eval(context).ConvertToDouble();
			return Math.Pow(a, b);
		}
	}
}
