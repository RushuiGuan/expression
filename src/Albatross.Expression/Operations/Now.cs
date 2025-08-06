using System;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class Now : PrefixExpression {
		public Now() : base("Now", 0, 0) { }

		public override object Eval(Func<string, object> context) {
			return System.DateTime.Now;
		}
	}
}
