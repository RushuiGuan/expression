using System.Collections.Generic;
using Albatross.Dates;


namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class PreviousWeekDay : PrefixExpression {
		public PreviousWeekDay() : base("PreviousWeekDay", 1, 2) { }

		public override object Run(List<object> operands) {
			var date = operands[0].ConvertToDateTime();
			var count = 1;
			if (this.Operands.Count > 1) {
				count = operands[1].ConvertToInt();
			}
			return date.PreviousWeekday(count);
		}
	}
}
