using System;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class Text : PrefixExpression {
		public Text() : base("Text", 1, 1) { }

		public override object Eval(Func<string, object> context) => this.GetValue(0, context).ConvertToString();
	}
}
