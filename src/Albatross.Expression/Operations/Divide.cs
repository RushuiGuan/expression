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

		public override object Run(object left, object right)
			=> left.ConvertToDouble() / right.ConvertToDouble();
	}
}