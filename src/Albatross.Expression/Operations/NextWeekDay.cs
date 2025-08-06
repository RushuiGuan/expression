using System;
using System.Linq;
using Albatross.Expression.Nodes;


namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class NextWeekDay : PrefixExpression {
		public NextWeekDay() : base("NextWeekDay", 1, 1) { }

		public override object? Eval(Func<string, object> context) {
			object a = GetRequiredOperandValues(context).First();
			if (a == null) { return null; }
			System.DateTime date;
			if (a is System.DateTime) {
				date = (System.DateTime)a;
			} else {
				if (!System.DateTime.TryParse(Convert.ToString(a), out date)) {
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
