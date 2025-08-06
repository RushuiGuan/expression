using System;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class Today : PrefixExpression {
		public Today() : base("Today", 0, 0) { }

		public override object Eval(Func<string, object> context) => System.DateTime.Today;
	}
}