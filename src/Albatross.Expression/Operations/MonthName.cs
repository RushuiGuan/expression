using System;
using System.Linq;
using Albatross.Expression.Nodes;
using Albatross.Expression.Exceptions;

using System.Globalization;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class MonthName : PrefixExpression {

		public override string Name { get { return "MonthName"; } }
		public override int MinOperandCount { get { return 1; } }
		public override int MaxOperandCount { get { return 1; } }
		public override bool Symbolic { get { return false; } }

		public override object? Eval(Func<string, object> context) {
			object value = GetOperands(context).First();

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
