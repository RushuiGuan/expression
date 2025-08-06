using System;
using Albatross.Expression.Nodes;

using System.Globalization;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class ShortMonthName : PrefixExpression {
		public ShortMonthName() : base("ShortMonthName", 1, 1) { }

		public override object Eval(Func<string, object> context) {
			var date = this.GetValue(0, context).ConvertToDateTime();
			return CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(date.Month);
		}
	}
}
