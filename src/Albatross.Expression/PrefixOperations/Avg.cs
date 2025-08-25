using Albatross.Expression.Nodes;
using System.Collections.Generic;
using System.Linq;

namespace Albatross.Expression.PrefixOperations {
	public class Avg : PrefixExpression {
		public Avg() : base("Avg", 0, int.MaxValue) { }

		public override object Run(List<object> items) {
			return items.Sum(x => x.ConvertToDouble()) / items.Count;
		}
	}
}