using System;
using System.Linq;
using Albatross.Expression.Tokens;


namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class NextWeekDay : PrefixOperationToken {

		public override string Name { get { return "NextWeekDay"; } }
		public override int MinOperandCount { get { return 1; } }
		public override int MaxOperandCount { get { return 1; } }
		public override bool Symbolic { get { return false; } }

		public override object EvalValue(Func<string, object> context) {
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
			if (date.DayOfWeek == System.DayOfWeek.Friday) {
				return date.AddDays(3);
			}else if (date.DayOfWeek == System.DayOfWeek.Saturday) {
				return date.AddDays(2);
			} else {
				return date.AddDays(1);
			}
		}
	}
}
