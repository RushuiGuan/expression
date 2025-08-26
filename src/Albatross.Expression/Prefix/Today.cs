using System;
using Albatross.Expression.Nodes;
using System.Collections.Generic;

namespace Albatross.Expression.Prefix {
	public class Today : PrefixExpression {
		public Today() : base("Today", 0, 0) { }

		public override object Run(List<object> operands) => DateTime.Today;
	}
}