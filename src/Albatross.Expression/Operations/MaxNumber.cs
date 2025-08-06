using System;
using Albatross.Expression.Nodes;
using System.Collections;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class MaxNumber : PrefixExpression {
		public MaxNumber() : base("Max", 1, int.MaxValue) { }

		public override object Eval(Func<string, object> context) {
			this.ValidateOperands();
			IEnumerable list = this.GetValues(context);
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
