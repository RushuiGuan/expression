using System;
using System.Collections.Generic;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Prefix {
	public class Now : PrefixExpression {
		public Now() : base("Now", 0, 0) { }

		protected override object Run(List<object> operands) {
			return System.DateTime.Now;
		}
	}
}
