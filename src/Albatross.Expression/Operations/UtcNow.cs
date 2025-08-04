using System;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class UtcNow : PrefixExpression {

		public override string Name { get { return "UtcNow"; } }
		public override int MinOperandCount { get { return 0; } }
		public override int MaxOperandCount { get { return 0; } }
		public override bool Symbolic { get { return false; } }

		public override object? Eval(Func<string, object> context) {
			return DateTime.UtcNow;
		}
	}
}
