using System;
using System.Collections.Generic;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.PrefixOperations {
	[ParserOperation]
	public class Now : PrefixExpression {
		public Now() : base("Now", 0, 0) { }

		public override object Run(List<object> operands) {
			return System.DateTime.Now;
		}
	}
}
