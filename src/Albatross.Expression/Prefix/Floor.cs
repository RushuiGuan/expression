using System;
using Albatross.Expression.Nodes;
using System.Collections.Generic;

namespace Albatross.Expression.Prefix {
	/// <summary>
	/// Floor the current number and remove all decimals
	/// </summary>
	public class Floor : PrefixExpression {
		public Floor() : base("Floor", 1, 1) { }

		protected override object Run(List<object> operands) {
			var value = operands[0].ConvertToDouble();
			return Math.Floor(value);
		}
	}
}