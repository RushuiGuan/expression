using System;
using System.Collections.Generic;
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

		public override object? Eval(Func<string, object> context) {
			int count;
			List<object> list = GetRequiredOperandValues(context);
			object value = list[1];

			if (value == null) { return list[0]; }

			if (value is double) {
				count = (int)Math.Round((double)value, 0);
			} else {
				throw new Exceptions.UnexpectedTypeException(value.GetType());
			}
			if (count < 0) {
				throw new Exceptions.OperandException("Left function expects a positive number for the second operand");
			}
			string text = Convert.ToString(list[0]);
			if (count > text.Length) {
				return text;
			} else {
				return text.Substring(0, count);
			}
		}
	}
}
