using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Nodes;
using System.Xml;
using Albatross.Expression.Exceptions;


namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class Year : PrefixExpression {
		public Year() : base("Year", 1, 1) { }

		public override object? Eval(Func<string, object> context) {
			object value = GetRequiredOperandValues(context).First();
			if (value == null) { return null; }
			else if (value is System.DateTime) {
				return Convert.ToDouble(((System.DateTime)value).Year);
			} else {
				System.DateTime datetime;
				if (System.DateTime.TryParse(Convert.ToString(value), out datetime)) {
					return Convert.ToDouble(datetime.Year);
				} else {
					throw new FormatException("Invalid DateTime Format");
				}
			}
		}
	}
}
