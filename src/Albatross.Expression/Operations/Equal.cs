using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using System.Xml;
using Albatross.Expression.Documentation.Attributes;
using Albatross.Expression.Documentation;

namespace Albatross.Expression.Operations {
	/// <summary>
	/// <para>Infix operation that perform an equal check</para>
	/// <para>Operand Count: 2</para>
	/// <list type="number">
	///		<listheader>
	///		<description>Operands</description>
	///		</listheader>
	///		<item><description>Operrand1 : double</description></item>
	///		<item><description>Operrand2 : double</description></item>
	/// </list>
	/// <para>Output Type: double</para>
	/// </summary>
	[OperationDoc(Group.Boolean, "@v1 {token} @v2",
		@"
### Returns true if the both sides of the equation are the same 

#### References:
- [{token}](https://help.workiom.com/article/formula#{token})
        ",
		@"
5 {token} 3
        "
	)]
	[ParserOperation]
	public class Equal : ComparisonInfixOperation {

		public override string Name { get { return "="; } }
		public override bool Symbolic { get { return true; } }
		public override int Precedence { get { return 50; } }

		public override bool interpret(int comparisonResult) {
			return comparisonResult == 0;
		}
	}
}
