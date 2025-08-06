using Albatross.Dates;
using System;
using Albatross.Expression.Nodes;


namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class NextWeekDay : PrefixExpression {
		public NextWeekDay() : base("NextWeekDay", 1, 2) { }

		public override object Eval(Func<string, object> context) {
			var value = this.GetValue(0, context).ConvertToDateTime();
			var count = 1;
			if (this.Operands.Count == 2) {
				count = this.GetValue(1, context).ConvertToInt();
			}
			return value.NextWeekday(count);
		}
	}
}
