using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using Albatross.Expression.Documentation.Attributes;
using Albatross.Expression.Documentation;


namespace Albatross.Expression.Operations {
	/// <summary>
	/// <para>Prefix operation that return the first non null operand</para>
	/// <para>Operand Count: 1 to infinite</para>
	/// <para>Operand Type: any</para>
	/// <para>Example: Coalesce(null, 1, 2, 3) will return 1</para>
	/// </summary>
	[OperationDoc(Group.Boolean, "{token}(o1,o2,...)",
		@"
### Prefix operation that returns the first non-null operand.	

#### References:
- [{token}](https://help.workiom.com/article/formula#{token})
        ",
		@"
{token}(null,1,2,3)
        "
	)]
	[ParserOperation]
	public class Coalesce : PrefixOperationToken {

		public override string Name { get { return "Coalesce"; } }
		public override int MinOperandCount { get { return 1; } }
		public override int MaxOperandCount { get { return int.MaxValue; } }
		public override bool Symbolic { get { return false; } }

		public override object EvalValue(Func<string, object> context) {
			List<object> list = GetOperands(context);
			foreach (object obj in list) {
				if (obj != null) {
					return obj;
				}
			}
			return null;
		}
	}
}
