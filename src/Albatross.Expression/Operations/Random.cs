using System;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class Random : PrefixExpression {
		public Random() : base("Random", 2, 2) { }

		public override object Eval(Func<string, object> context) {
			var min = this.GetValue(0, context).ConvertToInt();
			var max = this.GetValue(1, context).ConvertToInt();
			return System.Random.Shared.Next(min, max);
		}
	}
}
