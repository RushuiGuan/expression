using System;
using System.Collections.Generic;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Prefix {
	public class Number : PrefixExpression {
		public Number() : base("Number", 1, 1) { }

		protected override object Run(List<object> operands) {
			return operands[0].ConvertToDouble();
		}
	}
}
