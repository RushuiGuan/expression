using System;
using System.Linq;
using Albatross.Expression.Tokens;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class UnixTimestamp2DateTime : PrefixOperationToken {
		public override string Name { get { return "UnixTimestamp2DateTime"; } }
		public override int MinOperandCount { get { return 1; } }
		public override int MaxOperandCount { get { return 1; } }
		public override bool Symbolic { get { return false; } }

		public override object EvalValue(Func<string, object> context) {
			object value = GetOperands(context).First();
			long seconds = Convert.ToInt64(value);
			return DateTimeOffset.FromUnixTimeSeconds(seconds);
		}
	}
}