using System;
using System.Linq;
using Albatross.Expression.Tokens;


namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class PreviousWeekDay : PrefixOperationToken {

		public override string Name { get { return "PreviousWeekDay"; } }
		public override int MinOperandCount { get { return 1; } }
		public override int MaxOperandCount { get { return 1; } }
		public override bool Symbolic { get { return false; } }

		public override object? Eval(Func<string, object> context) {
			object a = GetOperands(context).First();
			if (a == null) { return null; }
			DateTime date;
			if (a is DateTime) {
				date = (DateTime)a;
			} else {
				if (!DateTime.TryParse(Convert.ToString(a), out date)) {
					throw new FormatException("Invalid Datetime Format");
				}
			}
			if (date.DayOfWeek == System.DayOfWeek.Monday) {
				return date.AddDays(-3);
			}else if (date.DayOfWeek == System.DayOfWeek.Sunday) {
				return date.AddDays(-2);
			} else {
				return date.AddDays(-1);
			}
		}
	}
}
