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
			object value = GetOperands(context).First();
			if (value == null) { return null; }
			else if (value is DateTime) {
				return Convert.ToDouble(((DateTime)value).Year);
			} else {
				DateTime datetime;
				if (DateTime.TryParse(Convert.ToString(value), out datetime)) {
					return Convert.ToDouble(datetime.Year);
				} else {
					throw new FormatException("Invalid DateTime Format");
				}
			}
		}
	}
}
