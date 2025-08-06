using System;
using Albatross.Expression.Nodes;
using System.Globalization;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class MonthName : PrefixExpression {
		public MonthName() : base("MonthName", 1, 1) { }

		public override object Eval(Func<string, object> context) {
			var value = this.GetValue(0, context).ConvertToDateTime();
			return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(value.Month);
		}
	}
}