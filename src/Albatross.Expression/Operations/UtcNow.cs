using System;
using Albatross.Expression.Tokens;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class UtcNow : PrefixOperationToken {

		public override string Name { get { return "UtcNow"; } }
		public override int MinOperandCount { get { return 0; } }
		public override int MaxOperandCount { get { return 0; } }
		public override bool Symbolic { get { return false; } }

		public override object EvalValue(Func<string, object> context) {
			return DateTime.UtcNow;
		}
	}
}
