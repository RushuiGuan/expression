using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using System.Xml;
using Albatross.Expression.Exceptions;
using System.Globalization;
using Albatross.Expression.Documentation.Attributes;
using Albatross.Expression.Documentation;

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
	[FunctionDoc(Group.Text, "{token}(@string,@num)",
		@"
### Extracts the specified number of characters from the beginning of the string.
#### Inputs:
- string: String
- num: Integer
#### Outputs:
- String

#### References:
- [{token}](https://help.workiom.com/article/formula#{token})
        ",
		@"
{token}(""Hello World"", 5)
        "
	)]
	[ParserOperation]
	public class Left : PrefixOperationToken {
		public override string Name { get { return "Left"; } }
		public override int MinOperandCount { get { return 2; } }
		public override int MaxOperandCount { get { return 2; } }
		public override bool Symbolic { get { return false; } }

		public override object EvalValue(Func<string, object> context) {
			int count;
			List<object> list = GetOperands(context);
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
