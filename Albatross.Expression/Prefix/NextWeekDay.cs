using Albatross.Dates;
using Albatross.Expression.Nodes;
using System.Collections.Generic;


namespace Albatross.Expression.Prefix {
	public class NextWeekDay : PrefixExpression {
		public NextWeekDay() : base("NextWeekDay", 1, 2) { }

		protected override object Run(List<object> operands) {
			var value = operands[0].ConvertToDateTime();
			var count = 1;
			if (this.Operands.Count == 2) {
				count = operands[1].ConvertToInt();
			}
			return value.NextWeekday(count);
		}
	}
}
