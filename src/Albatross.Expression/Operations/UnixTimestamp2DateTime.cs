using System;
using System.Linq;
using Albatross.Expression.Tokens;

namespace Albatross.Expression.Operations {
	/// <summary>
	/// Converts a Unix time expressed as the number of seconds that have elapsed since 1970-01-01T00:00:00Z to utc datetime.
	/// </summary>
	[ParserOperation]
	public class UnixTimestamp2DateTime : PrefixOperationToken {
		public override string Name { get { return "UnixTimestamp2DateTime"; } }
		public override int MinOperandCount { get { return 1; } }
		public override int MaxOperandCount { get { return 1; } }
		public override bool Symbolic { get { return false; } }

		public override object EvalValue(Func<string, object> context) {
			object value = GetOperands(context).First();
			long seconds = Convert.ToInt64(value);
			var item = DateTimeOffset.FromUnixTimeSeconds(seconds).UtcDateTime;
			return item;
		}
	}
}