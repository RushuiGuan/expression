using System;
using Albatross.Expression.Nodes;
using System.Collections.Generic;

namespace Albatross.Expression.Prefix {
	public class UtcNow : PrefixExpression {
		public UtcNow() : base("UtcNow", 0, 0) { }
		protected override object Run(List<object> operands) => System.DateTime.UtcNow;
	}
}
