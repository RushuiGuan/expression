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
	/// <para>Infix OR operation.</para>
	/// 
	/// <para>Operand Count: 2</para>
	/// <list type="number">
	///		<listheader>
	///		<description>Operands</description>
	///		</listheader>
	///		<item><description>Operand1 : any</description></item>
	///		<item><description>Operand2 : any</description></item>
	/// </list>
	/// 
	/// <para>Output Type: Boolean</para>
	/// <para>Usage: 3 > 2 or 2 > 1</para>
	/// <para>Precedance: 20</para>
	/// </summary>
	[OperationDoc(Group.Boolean, "@expression {token} @expression",
		@"
### Logical OR operation

#### References:
- [{token}](https://help.workiom.com/article/formula#{token})
        ",
		@"
(a > 5) {token} (b > 6)
        "
	)]
	[ParserOperation]
	public class Or : InfixOperationToken {
		
		public override string Name { get { return "or"; } }
		public override bool Symbolic { get { return true; } }
		public override int Precedence { get { return 20; } }

		public override object EvalValue(Func<string, object> context) {
			object value = Operand1.EvalValue(context);
			if (value.ConvertToBoolean()) {
				return true;
			} else {
				value = Operand2.EvalValue(context);
				return value.ConvertToBoolean();
			}
		}
	}
}
