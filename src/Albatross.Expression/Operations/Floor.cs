using System;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Operations {
	/// <summary>
	/// Floor the current number and remove all decimals
	/// </summary>
	[ParserOperation]
	public class Floor : PrefixExpression {
		public Floor() : base("Floor", 1, 1) { }

		public override object? Eval(Func<string, object> context) {
			var obj = this.GetValue(0, context);
			if (obj == null) {
				return null;
			} else {
				var value = obj.ConvertToDouble();
				return Math.Floor(value);
			}
		}
	}
}
