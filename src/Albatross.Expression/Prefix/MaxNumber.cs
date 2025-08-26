using System;
using Albatross.Expression.Nodes;
using System.Collections;
using System.Collections.Generic;

namespace Albatross.Expression.Prefix {
	public class MaxNumber : PrefixExpression {
		public MaxNumber() : base("Max", 1, int.MaxValue) { }

		protected override object Run(List<object> list) {
			var current = double.MinValue;
			foreach (var item in list) {
				var value = item.ConvertToDouble();
				if (value > current) {
					current = value;
				}
			}
			return current;
		}
	}
}
