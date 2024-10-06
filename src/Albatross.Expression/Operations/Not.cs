using System;
using System.Linq;
using Albatross.Expression.Tokens;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class Not : PrefixOperationToken {
		public override string Name { get { return "not"; } }
		public override int MinOperandCount { get { return 1; } }
		public override int MaxOperandCount { get { return 1; } }
		public override bool Symbolic { get { return false; } }

		public override object? EvalValue(Func<string, object> context) {
			var value = GetOperands(context).First();
			return !value.ConvertToBoolean();
		}
	}
}
