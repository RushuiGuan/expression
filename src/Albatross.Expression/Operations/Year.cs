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
			var value = this.GetValue(0, context);
			if (value == null) {
				return null;
			} else {
				var datetime = value.ConvertToDateTime();
				return Convert.ToDouble(datetime.Year);
			}
		}
	}
}
