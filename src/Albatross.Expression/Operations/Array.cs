using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using Albatross.Expression.Documentation.Attributes;
using Albatross.Expression.Documentation;


namespace Albatross.Expression.Operations {
	/// <summary>
	/// <para>Prefix operation that create an object array</para>
	/// <para>Operand Count: 0 to infinite</para>
	/// <para>Operand Type: Any</para>
	/// <para>Output Type: <see cref="System.Collections.Generic.List{T}"/> where T is Object</para>
	/// <para>Usage: @(1, 2, 3, 4, 5)</para>
	/// </summary>
	[OperationDoc(Group.Boolean, "{token}(v1,v2,...)",
		@"
### Return array of passed values

#### References:
- [{token}](https://help.workiom.com/article/formula#{token})
        ",
		@"
{token}(1,2,3)
        "
	)]
	[ParserOperation]
	public class Array : PrefixOperationToken {
		public override string Name { get { return "@"; } }
		public override int MinOperandCount { get { return 0; } }
		public override int MaxOperandCount { get { return int.MaxValue; } }
		public override bool Symbolic { get { return false; } }

		public override object EvalValue(Func<string, object> context) {
			return GetOperands(context);
		}
	}
}
