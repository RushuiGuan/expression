using System;
using Albatross.Expression.Nodes;
using System.Collections.Generic;


namespace Albatross.Expression.Prefix {
	public class DayOfWeek : PrefixExpression {
		public DayOfWeek() : base("DayOfWeek", 1, 1) { }

		protected override object Run(List<object> operands) {
			var dateTime = operands[0].ConvertToDateTime();
			return Convert.ToDouble(dateTime.DayOfWeek);
		}
	}
}
