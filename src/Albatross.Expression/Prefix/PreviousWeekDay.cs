using System.Collections.Generic;
using Albatross.Dates;


namespace Albatross.Expression.Prefix {
	public class PreviousWeekDay : PrefixExpression {
		public PreviousWeekDay() : base("PreviousWeekDay", 1, 2) { }

		protected override object Run(List<object> operands) {
			var date = operands[0].ConvertToDateTime();
			var count = 1;
			if (this.Operands.Count > 1) {
				count = operands[1].ConvertToInt();
			}
			return date.PreviousWeekday(count);
		}
	}
}
