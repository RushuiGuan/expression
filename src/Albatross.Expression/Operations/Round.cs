using System;
using System.Collections.Generic;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Operations {
	/// <summary>
	/// Perform a mid point rounding away from zero.  First operand is the input, second operand is the number of digits.
	/// </summary>
	[ParserOperation]
	public class Round : PrefixExpression {
		public Round() : base("Round", 2, 2) { }

		public override object Run(List<object> operands) {
			var value = operands[0].ConvertToDouble();
			var digit = operands[1].ConvertToInt();
			return Math.Round(value, digit, MidpointRounding.AwayFromZero);
		}
	}
}
