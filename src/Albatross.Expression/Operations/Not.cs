using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using Albatross.Expression.Documentation.Attributes;
using Albatross.Expression.Documentation;

namespace Albatross.Expression.Operations {
	[OperationDoc(Group.Boolean, "{token} @v",
		@"
### Returns true if the operand is not true.

#### References:
- [{token}](https://help.workiom.com/article/formula#{token})
        ",
		@"
{token}(5>10)
        "
	)]
	[ParserOperation]
	public class Not : PrefixOperationToken {
		public override string Name { get { return "not"; } }
		public override int MinOperandCount { get { return 1; } }
		public override int MaxOperandCount { get { return 1; } }
		public override bool Symbolic { get { return false; } }

		public override object EvalValue(Func<string, object> context) {
			object value = Operands.First().EvalValue(context);
			return !value.ConvertToBoolean();
		}
	}
}
