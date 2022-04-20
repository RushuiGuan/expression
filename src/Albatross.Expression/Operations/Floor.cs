using System;
using System.Collections.Generic;
using Albatross.Expression.Tokens;

namespace Albatross.Expression.Operations {
	/// <summary>
	/// Floor the current number and remove all decimals
	/// </summary>
	[ParserOperation]
	public class Floor : PrefixOperationToken {
		public override string Name { get { return "Floor"; } }
		public override int MinOperandCount { get { return 1; } }
		public override int MaxOperandCount { get { return 1; } }
		public override bool Symbolic { get { return false; } }

		public override object EvalValue(Func<string, object> context) {
			List<object> list = GetOperands(context);
			try {
				var value = Convert.ToDouble(list[0]);
				return Math.Floor((double)value);
			} catch (FormatException) {
				throw new Exceptions.UnexpectedTypeException(list[0].GetType());
			}
		}
	}
}
