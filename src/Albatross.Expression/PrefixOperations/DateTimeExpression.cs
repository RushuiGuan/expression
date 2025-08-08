using Albatross.Expression.Nodes;
using System.Collections.Generic;

namespace Albatross.Expression.PrefixOperations {
	/// <summary>
	/// <para>Prefix operation that convert input to DateTime</para>
	/// <para>Operand Count: 1</para>
	/// <list type="number">
	///		<listheader>
	///		<description>Operands</description>
	///		</listheader>
	///		<item><description>input : any</description></item>
	/// </list>
	/// <para>Output Type: System.DateTime</para>
	/// </summary>
	[ParserOperation]
	public class DateTimeExpression : PrefixExpression {
		public DateTimeExpression() : base("DateTime", 1, 1) { }

		public override object Run(List<object> operands) => operands[0].ConvertToDateTime();
	}
}