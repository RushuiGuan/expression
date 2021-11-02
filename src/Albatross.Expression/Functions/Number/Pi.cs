using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using Albatross.Expression.Documentation.Attributes;
using Albatross.Expression.Documentation;

namespace Albatross.Expression.Operations {
	[FunctionDoc(Group.Number, "{token}()",
		@"
### Return PI value
#### Inputs:
- No inputs
#### Outputs:
- Double.

#### References:
- [{token}](https://help.workiom.com/article/formula#{token})
        ",
		@"
{token}()
        "
	)]
	[ParserOperation]
	public class Pi : PrefixOperationToken {
		
		public override string Name { get { return "pi"; } }
		public override int MinOperandCount { get { return 0; } }
		public override int MaxOperandCount { get { return 0; } }
		public override bool Symbolic { get { return false; } }

		public override object EvalValue(Func<string, object> context) {
			return Math.PI;
		}
	}
}
