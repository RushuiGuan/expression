using System;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Infix {
	/// <summary>
	/// <para>Infix operation that perform an plus operation</para>
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
	public class Plus : InfixExpression {
		public Plus() : base("+", 100) { }

		public override object Run(object left, object right) {
			return left.ConvertToDouble() + right.ConvertToDouble();
		}
	}
}
