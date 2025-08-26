using System;
using System.Collections.Generic;
using Albatross.Expression.Nodes;


namespace Albatross.Expression.Prefix {
	public class Month : PrefixExpression {
		public Month() : base("Month", 1, 1) { }

		protected override object Run(List<object> operands) {
			return operands[0].ConvertToDateTime().Month;
		}
	}
}
