using System;
using Albatross.Expression.Nodes;

using System.Globalization;
using System.Collections.Generic;

namespace Albatross.Expression.PrefixOperations {
	public class ShortMonthName : PrefixExpression {
		public ShortMonthName() : base("ShortMonthName", 1, 1) { }

		public override object Run(List<object> operands) {
			var date = operands[0].ConvertToDateTime();
			return CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(date.Month);
		}
	}
}
