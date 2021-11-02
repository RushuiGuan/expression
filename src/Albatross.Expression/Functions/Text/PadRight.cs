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
	[FunctionDoc(Group.Text, "{token}(@totalWidth,@paddingChar)",
		@"
### Returns a new string that left-aligns the characters in this instance by padding them on the right with a specified Unicode character, for a specified total length.
#### Inputs:
- totalWidth: Integer
- paddingChar: Char
#### Outputs:
- String

#### References:
- [{token}](https://help.workiom.com/article/formula#{token})
        ",
		@"
{token}(5,'.')
        "
	)]
	[ParserOperation]
	public class PadRight : PrefixOperationToken {
		public const char DefaultPaddingCharacter = ' ';
		public override string Name { get { return "PadRight"; } }
		public override int MinOperandCount { get { return 2; } }
		public override int MaxOperandCount { get { return 3; } }
		public override bool Symbolic { get { return false; } }


		public override object EvalValue(Func<string, object> context) {
			int count;
			List<object> list = GetOperands(context);
			object value = list[1];
			if (value == null) { return list[0]; }

			if (value is double){
				count = (int)Math.Round((double)value, 0);
			} else {
				throw new Exceptions.UnexpectedTypeException(value.GetType());
			}
			char paddingChar;
			if (list.Count == 2 || string.IsNullOrEmpty(Convert.ToString(list[2]))) {
				paddingChar = DefaultPaddingCharacter;
			} else {
				paddingChar = Convert.ToString(list[2]).First();
			}

			return Convert.ToString(list[0]).PadRight(count, paddingChar);
		}
	}
}
