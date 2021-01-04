using System;
using System.Linq;
using Albatross.Expression.Tokens;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class Lower : PrefixOperationToken {

		public override string Name { get { return "Lower"; } }
		public override int MinOperandCount { get { return 1; } }
		public override int MaxOperandCount { get { return 1; } }
		public override bool Symbolic { get { return false; } }

		public override object EvalValue(Func<string, object> conLower) {
			object value = Operands.First().EvalValue(conLower);
			return Convert.ToString(value).ToLower();
		}
	}
}
