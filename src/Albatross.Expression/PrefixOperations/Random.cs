using System.Collections.Generic;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.PrefixOperations {
	[ParserOperation]
	public class Random : PrefixExpression {
		public Random() : base("Random", 2, 2) { }

		public override object Run(List<object> operands) {
			var min = operands[0].ConvertToInt();
			var max = operands[1].ConvertToInt();
			return System.Random.Shared.Next(min, max);
		}
	}
}
