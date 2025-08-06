using System;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class Numeric : PrefixExpression {
		public Numeric() : base("Numeric", 1, 1) { }

		public override object Eval(Func<string, object> context) {
			object value = this.GetValue(0, context);
			return Convert.ToDouble(value);
		}
	}
}
