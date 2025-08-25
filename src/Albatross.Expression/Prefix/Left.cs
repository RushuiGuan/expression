using Albatross.Expression.Exceptions;
using System.Collections.Generic;

namespace Albatross.Expression.Prefix {
	/// <summary>
	/// <para>Prefix operation that return the substring of the input text with the specified length and start index of 0</para>
	/// <para>Operand Count: 2</para>
	/// <list type="number">
	///		<listheader>
	///		<description>Operands</description>
	///		</listheader>
	///		<item><description>input: string</description></item>
	///		<item><description>count: double</description></item>
	/// </list>
	/// <para>Output Type: string</para>
	/// <para>Usage: Left("test", 1) should return "t"</para>
	/// </summary>
	public class Left : PrefixExpression {
		public Left() : base("Left", 2, 2) { }

		public override object Run(List<object> operands) {
			var text = operands[0].ConvertToString();
			var count = operands[1].ConvertToInt();
			if (count < 0) {
				throw new OperandException("Left operation expects a positive number for the second parameter");
			}
			return text.Substring(0, count);
		}
	}
}
