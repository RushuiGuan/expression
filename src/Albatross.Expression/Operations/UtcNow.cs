using System;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class UtcNow : PrefixExpression {
		public UtcNow() : base("UtcNow", 0, 0) { }
		public override object Eval(Func<string, object> context) => System.DateTime.UtcNow;
	}
}
