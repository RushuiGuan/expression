using System;
using System.Linq;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class Upper : PrefixExpression {
		public Upper() : base("Upper", 1, 1) { }

		public override object? Eval(Func<string, object> context) {
			object value = GetOperands(context).First();
			return Convert.ToString(value).ToUpper();
		}
	}
}
