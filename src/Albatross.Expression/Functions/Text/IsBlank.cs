using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using System.Xml;
using Albatross.Expression.Exceptions;
using Albatross.Expression.Documentation.Attributes;
using Albatross.Expression.Documentation;

namespace Albatross.Expression.Operations {
	/// <summary>
	/// <para>Prefix operation to check if the input IsBlank</para>
	/// <para>Operand Type: any</para>
	/// <para>Null, empty string and string with only white space are considered as blank</para>
	/// </summary>
	[FunctionDoc(Group.Text, "{token}(@value)",
		@"
### Returns boolean value, true if the value is blank, false if not.  Null, empty string, string with only white space are considered as blank.
#### Inputs:
- value: String

#### Outputs:
- Boolean

#### References:
- [{token}](https://help.workiom.com/article/formula#{token})
        ",
		@"
{token}("""")
        "
	)]
	[ParserOperation]
	public class IsBlank : PrefixOperationToken {

		public override string Name { get { return "IsBlank"; } }
		public override int MinOperandCount { get { return 1; } }
		public override int MaxOperandCount { get { return 1; } }
		public override bool Symbolic { get { return false; } }

		public override object EvalValue(Func<string, object> context) {
			object value = GetOperands(context).First();

			if (value == null) {
				return true;
			} else if (value is string) {
				return string.IsNullOrWhiteSpace((string)value);
			} else {
				return false;
			}
		}
	}
}
