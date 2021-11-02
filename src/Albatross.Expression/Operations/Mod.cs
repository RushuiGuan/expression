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
	/// <para>Infix operation that perform an mod operation</para>
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
### Returns the remainder after dividing the first operand with the second.

#### References:
- [{token}](https://help.workiom.com/article/formula#{token})
        ",
		@"
5 {token} 3
        "
	)]
	[ParserOperation]
	public class Mod : InfixOperationToken {

		public override string Name { get { return "%"; } }
		public override bool Symbolic { get { return true; } }
		public override int Precedence { get { return 200; } }

		public override object EvalValue(Func<string, object> context) {
			object a = Operand1.EvalValue(context);
			object b = Operand2.EvalValue(context);

			if (a == null || b == null) { return null; }

			if (a is double && b is double){
				return (double)a % (double)b;
			} else {
				throw new Exceptions.UnexpectedTypeException(a.GetType());
			}
		}
	}
}
