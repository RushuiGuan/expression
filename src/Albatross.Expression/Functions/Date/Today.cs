using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using Albatross.Expression.Documentation;
using Albatross.Expression.Documentation.Attributes;

namespace Albatross.Expression.Operations {
	[FunctionDoc(Group.Date, "{token}()",
		@"
### Create date object represent current date

#### Inputs:
- No inputs

#### Outputs:
- Date.

#### References:
- [{token}](https://help.workiom.com/article/formula#{token})
        ",
		@"
{token}()
        "
	)]
	[ParserOperation]
	public class Today : PrefixOperationToken {
		
		public override string Name { get { return "Today"; } }
		public override int MinOperandCount { get { return 0; } }
		public override int MaxOperandCount { get { return 0; } }
		public override bool Symbolic { get { return false; } }

		public override object EvalValue(Func<string, object> context) {
			return DateTime.Today;
		}
	}
}
