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
	[FunctionDoc(Group.Text, "{token}(@string)",
		@"
### Removes the empty spaces from the beginning of the string.
#### Inputs:
- string: String

#### Outputs:
- String

#### References:
- [{token}](https://help.workiom.com/article/formula#{token})
        ",
		@"
{token}(""Sample text"")
        "
	)]
	[ParserOperation]
	public class TrimLeft : PrefixOperationToken {

		public override string Name { get { return "TrimLeft"; } }
		public override int MinOperandCount { get { return 1; } }
		public override int MaxOperandCount { get { return 1; } }
		public override bool Symbolic { get { return false; } }

		public override object EvalValue(Func<string, object> context) {
			object value = Operands.First().EvalValue(context);
			return Convert.ToString(value).TrimStart();
		}
	}
}
