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
### Positive sign

#### References:
- [{token}](https://help.workiom.com/article/formula#{token})
        ",
		@"
{token} 1
        "
	)]
	[ParserOperation]
	public class Positive : PrefixOperationToken {

		public override string Name { get { return "+"; } }
		public override int MinOperandCount { get { return 1; } }
		public override int MaxOperandCount { get { return 1; } }
		public override bool Symbolic { get { return true; } }

		public override object EvalValue(Func<string, object> context) {
			object a = Operands.First().EvalValue(context);

			if(a == null || a is double) { return a; }
			throw new Exceptions.UnexpectedTypeException(a.GetType());
		}
	}
}
