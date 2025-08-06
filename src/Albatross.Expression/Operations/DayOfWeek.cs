using System;
using Albatross.Expression.Nodes;


namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class DayOfWeek : PrefixExpression {
		public DayOfWeek() : base("DayOfWeek", 1, 1) { }
		public override object? Eval(Func<string, object> context) {
			var value = this.GetValue(0, context);
			if (value == null) { return null; }
			if (value is System.DateTime datetime) {
				return Convert.ToDouble(datetime.DayOfWeek);
			} else if (value is DateOnly dateOnly) {
				return Convert.ToDouble(dateOnly.DayOfWeek);
			} else if (value is string text && DateOnly.TryParse(text, out dateOnly)) {
				return Convert.ToDouble(dateOnly.DayOfWeek);
			}
			throw new FormatException($"Cannot calculate DayOfWeek from {value}.  Expected DateTime, DateOnly, or parsable string representation of a date.");
		}
	}
}
