using System;
using System.Linq;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Operations {
	/// <summary>
	/// Converts a Unix time expressed as the number of seconds that have elapsed since 1970-01-01T00:00:00Z to utc datetime.
	/// </summary>
	[ParserOperation]
	public class UnixTimestamp2DateTime : PrefixExpression {
		public UnixTimestamp2DateTime() : base("UnixTimestamp2DateTime", 1, 1) { }
		
		public override object? Eval(Func<string, object> context) {
			object value = GetOperands(context).First();
			long seconds = Convert.ToInt64(value);
			var item = DateTimeOffset.FromUnixTimeSeconds(seconds).UtcDateTime;
			return item;
		}
	}
}