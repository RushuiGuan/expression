using Albatross.Expression.Nodes;
using System.Globalization;
using System.Collections.Generic;

namespace Albatross.Expression.PrefixOperations {
	[ParserOperation]
	public class MonthName : PrefixExpression {
		public MonthName() : base("MonthName", 1, 1) { }

		public override object Run(List<object> operands) {
			var value = operands[0].ConvertToDateTime();
			return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(value.Month);
		}
	}
}