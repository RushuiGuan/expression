using System;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class Lower : PrefixExpression {
		public Lower() : base("Lower", 1, 1) { }

		public override object Eval(Func<string, object> context)
			=> this.GetRequiredStringValue(0, context).ToLowerInvariant();
	}
}