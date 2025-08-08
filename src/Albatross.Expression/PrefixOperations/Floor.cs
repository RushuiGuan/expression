using System;
using Albatross.Expression.Nodes;
using System.Collections.Generic;

namespace Albatross.Expression.PrefixOperations {
	/// <summary>
	/// Floor the current number and remove all decimals
	/// </summary>
	[ParserOperation]
	public class Floor : PrefixExpression {
		public Floor() : base("Floor", 1, 1) { }

		public override object Run(List<object> operands) {
			var value = operands[0].ConvertToDouble();
			return Math.Floor(value);
		}
	}
}