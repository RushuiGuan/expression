using System;
using Albatross.Expression.Nodes;
using System.Collections.Generic;


namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class DayOfWeek : PrefixExpression {
		public DayOfWeek() : base("DayOfWeek", 1, 1) { }

		public override object Run(List<object> operands) {
			var dateTime = operands[0].ConvertToDateTime();
			return Convert.ToDouble(dateTime.DayOfWeek);
		}
	}
}
