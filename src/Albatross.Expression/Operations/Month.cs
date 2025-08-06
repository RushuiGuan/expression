using System;
using System.Linq;
using Albatross.Expression.Nodes;


namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class Month : PrefixExpression {
		public Month() : base("Month", 1, 1) { }

		public override object? Eval(Func<string, object> context) {
			object a = GetRequiredOperandValues(context).First();
			if (a == null) { return null; }
			if (a is System.DateTime) {
				return Convert.ToDouble(((System.DateTime)a).Month);
			} else {
				System.DateTime datetime;
				if (System.DateTime.TryParse(Convert.ToString(a), out datetime)) {
					return Convert.ToDouble(datetime.Month);
				} else {
					throw new FormatException("Invalid Datetime Format");
				}
			}
		}
	}
}
