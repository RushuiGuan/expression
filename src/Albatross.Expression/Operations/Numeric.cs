using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Nodes;
using System.Xml;
using Albatross.Expression.Exceptions;

using System.Globalization;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class Numeric : PrefixExpression {
		public Numeric() : base("Numeric", 1, 1) { }

		public override object? Eval(Func<string, object> context) {
			object value = GetOperands(context).First();
			return Convert.ToDouble(value);
		}
	}
}
