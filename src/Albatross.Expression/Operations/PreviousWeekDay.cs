using System;
using System.Collections.Generic;
using System.Linq;
using Albatross.Dates;
using Albatross.Expression.Nodes;


namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class PreviousWeekDay : PrefixExpression {
		public PreviousWeekDay() : base("PreviousWeekDay", 1, 2) { }

		public override object Eval(Func<string, object> context) {
			var date = this.GetValue(0, context).ConvertToDateTime();
			var count = 1;
			if (this.Operands.Count > 1) {
				count = this.GetValue(1, context).ConvertToInt();
			}
			return date.PreviousWeekday(count);
		}

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
