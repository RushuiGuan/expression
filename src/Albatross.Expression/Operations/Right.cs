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
	public class Right : PrefixExpression {
		public Right() : base("Right", 2, 2) { }
		
		public override object? Eval(Func<string, object> context) {
			int count;
			List<object> list = GetRequiredOperandValues(context);
			object value = list[1];

			if (value == null) { return list[0]; }

			if (value is double) {
				count = (int)Math.Round((double)value, 0);
			} else {
				throw new Exceptions.UnexpectedTypeException(value.GetType());
			}
			if (count < 0) {
				throw new Exceptions.OperandException("Right function expects a positive number for the second operand");
			}
			string text = Convert.ToString(list[0]);
			if (count > text.Length) {
				return text;
			} else {
				return text.Substring(text.Length - count, count);
			}
		}
	}
}
