using System;
using System.Linq;
using Albatross.Expression.Tokens;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class Upper : PrefixOperationToken {

		public override string Name { get { return "Upper"; } }
		public override int MinOperandCount { get { return 1; } }
		public override int MaxOperandCount { get { return 1; } }
		public override bool Symbolic { get { return false; } }

		public override object EvalValue(Func<string, object> conUpper) {
			object value = Operands.First().EvalValue(conUpper);
			return Convert.ToString(value).ToUpper();
		}
	}
}
