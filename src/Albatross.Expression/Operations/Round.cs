using System;
using Albatross.Expression.Tokens;

namespace Albatross.Expression.Operations {
	/// <summary>
	/// Perform a mid point rounding away from zero.  First operand is the input, second operand is the number of digits.
	/// </summary>
	[ParserOperation]
	public class Round : PrefixOperationToken {
		public override string Name { get { return "Round"; } }
		public override int MinOperandCount { get { return 2; } }
		public override int MaxOperandCount { get { return 2; } }
		public override bool Symbolic { get { return false; } }

		public override object? EvalValue(Func<string, object> context) {
			var list = GetOperands(context);
			object? op1 = list[0];
			object? op2 = list[1];

			if (op1 == null || op2 == null) {
				return null;
			} else {
				var value = Convert.ToDouble(op1);
				var digit = Convert.ToInt32(op2);
				return Math.Round(value, digit);
			}
		}
	}
}
