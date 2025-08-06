using System;
using System.Linq;
using Albatross.Expression.Nodes;
using Albatross.Expression.Exceptions;

using System.Globalization;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class MonthName : PrefixExpression {
		public MonthName() : base("MonthName", 1, 1) { }

		public override object? Eval(Func<string, object> context) {
			object value = GetRequiredOperandValues(context).First();

			if (value == null) {
				return null;
			} else if (value is double) {
				return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(value));
			} else {
				throw new UnexpectedTypeException(value.GetType());
			}
		}
	}
}
