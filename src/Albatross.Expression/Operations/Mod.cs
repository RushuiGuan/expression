using System;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Operations {
	/// <summary>
	/// <para>Infix operation that perform an mod operation</para>
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
	[ParserOperation]
	public class Mod : InfixExpression {
		public Mod() : base("%", 200) { }

		public override object? Eval(Func<string, object> context) {
			var a = Left.Eval(context).ConvertToDouble();
			var b = Right.Eval(context).ConvertToDouble();
			return a % b;
		}
	}
}
