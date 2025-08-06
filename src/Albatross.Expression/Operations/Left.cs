using Albatross.Expression.Exceptions;
using System;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Operations {
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
	[ParserOperation]
	public class Left : PrefixExpression {
		public Left() : base("Left", 2, 2) { }

		public override object Eval(Func<string, object> context) {
			var text = this.GetStringValue(0, context);
			var count = this.GetValue(1, context).ConvertToInt();
			if (count < 0) {
				throw new OperandException("Left operation expects a positive number for the second parameter");
			}
			return text.Substring(0, count);
		}
	}
}
