using System;
using System.Collections.Generic;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.PrefixOperations {
	[ParserOperation]
	public class MinNumber : PrefixExpression {
		public MinNumber() : base("Min", 0, int.MaxValue) { }

		public override object Run(List<object> operands) {
			var current = double.MaxValue;
			foreach (var value in operands) {
				var item = value.ConvertToDouble();
				if (item < current) {
					current = item;
				}
			}
			return current;
		}
	}
}
