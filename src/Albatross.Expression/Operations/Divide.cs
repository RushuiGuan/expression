using System;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Operations {
	/// <summary>
	/// <para>Infix operation that perform divide</para>
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
	public class Divide : InfixExpression {
		public Divide() : base("/", 200) { }

		public override object? Eval(Func<string, object> context) {
			var a = Operand1.Eval(context);
			var b = Operand2.Eval(context);
			
			if (a == null || b == null) { return null; }

			if (a is double aa && b is double bb) {
				return aa / bb;
			} else {
				throw new Exceptions.UnexpectedTypeException(a.GetType());
			}
		}
	}
}
