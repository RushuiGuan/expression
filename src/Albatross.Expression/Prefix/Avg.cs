using Albatross.Expression.Nodes;
using System.Collections.Generic;
using System.Linq;

namespace Albatross.Expression.Prefix {
	public class Avg : PrefixExpression {
		public Avg() : base("Avg", 0, int.MaxValue) { }

		protected override object Run(List<object> items) {
			return items.Sum(x => x.ConvertToDouble()) / items.Count;
		}
	}
}