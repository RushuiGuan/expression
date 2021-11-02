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
	[FunctionDoc(Group.Text, "{token}(@object)",
		@"
### Transforms any object into a text.
#### Inputs:
- object: Any

#### Outputs:
- String

#### References:
- [{token}](https://help.workiom.com/article/formula#{token})
        ",
		@"
{token}(1)
        "
	)]
	[ParserOperation]
	public class Text : PrefixOperationToken {

		public override string Name { get { return "Text"; } }
		public override int MinOperandCount { get { return 1; } }
		public override int MaxOperandCount { get { return 1; } }
		public override bool Symbolic { get { return false; } }

		public override object EvalValue(Func<string, object> context) {
			object value = Operands.First().EvalValue(context);
			return Convert.ToString(value);
		}
	}
}
