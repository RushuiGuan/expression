using System;
using Albatross.Expression.Nodes;
using System.Collections;
using System.Linq;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class Avg : PrefixExpression {
		public Avg() : base("Avg", 0, int.MaxValue) { }

		public override object Eval(Func<string, object> context) {
			if (Operands.Count == 0) { return 0; }
			var items = this.GetValues(context);
			return items.Sum(x => x.ConvertToDouble()) / items.Count;
		}
	}
}