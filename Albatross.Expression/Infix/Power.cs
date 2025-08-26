using System;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Infix {
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
	public class Power : InfixExpression {
		public Power() : base("^", 300) { }

		protected override object Run(object left, object right) {
			var @base = left.ConvertToDouble();
			var power = right.ConvertToDouble();
			return Math.Pow(@base, power);
		}
	}
}