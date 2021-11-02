using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using System.Xml;
using Albatross.Expression.Documentation.Attributes;
using Albatross.Expression.Documentation;

namespace Albatross.Expression.Operations {
	[OperationDoc(Group.Boolean, "{token} @v",
		@"
### Multiply the numeric value with -1.

#### References:
- [{token}](https://help.workiom.com/article/formula#{token})
        ",
		@"
{token} 3
        "
	)]
	[ParserOperation]
	public class Negative : PrefixOperationToken {
		
		public override string Name { get { return "-"; } }
		public override int MinOperandCount { get { return 1; } }
		public override int MaxOperandCount { get { return 1; } }
		public override bool Symbolic { get { return true; } }

		public override object EvalValue(Func<string, object> context) {
			object a = Operands.First().EvalValue(context);

			if(a is double){
				return (double)a * -1;
			}
			throw new FormatException();
		}
	}
}
