using Albatross.Expression.Nodes;

namespace Albatross.Expression.InfixOperations {
	/// <summary>
	/// <para>Infix operation that perform an multiply operation</para>
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
	public class Multiply : InfixExpression {
		public Multiply() : base("*", 200) { }

		public override object Run(object left, object right) {
			return left.ConvertToDouble() * right.ConvertToDouble();
		}
	}
}
