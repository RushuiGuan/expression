using System;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class Random : PrefixExpression {
		public Random() : base("Random", 2, 2) { }

		public override object? Eval(Func<string, object> context) {
			var operands = GetOperands(context);
			int min = Convert.ToInt32(operands[0]);
			int max = Convert.ToInt32(operands[1]);
			return new System.Random().Next(min, max);
		}
	}
}
