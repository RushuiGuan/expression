using System;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class MinNumber : PrefixExpression {
		public MinNumber() : base("Min", 0, int.MaxValue) { }

		public override object Eval(Func<string, object> context) {
			this.ValidateOperands();
			var current = double.MaxValue;
			foreach(var value in this.GetValues(context)) {
				var item = value.ConvertToDouble();
				if (item < current) {
					current = item;
				}
			}
			return current;
		}
	}
}
