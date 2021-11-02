using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using System.Xml;
using Albatross.Expression.Documentation.Attributes;
using Albatross.Expression.Documentation;

namespace Albatross.Expression.Operations {
	[OperationDoc(Group.Boolean, "@v1 {token} @v2",
		@"
### Returns true if the both sides of the equation are not the same 

#### References:
- [{token}](https://help.workiom.com/article/formula#{token})
        ",
		@"
5 {token} 3
        "
	)]
	[ParserOperation]
	public class NotEqual : ComparisonInfixOperation {


		public override string Name { get { return "<>"; } }
		public override bool Symbolic { get { return true; } }
		public override int Precedence { get { return 100; } }

		public override bool interpret(int comparisonResult) {
			return comparisonResult != 0;
		}
	}
}
