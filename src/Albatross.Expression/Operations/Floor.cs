using System;
using System.Collections.Generic;
using Albatross.Expression.Tokens;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class Floor : PrefixOperationToken {
		public override string Name { get { return "Floor"; } }
		public override int MinOperandCount { get { return 1; } }
		public override int MaxOperandCount { get { return 1; } }
		public override bool Symbolic { get { return false; } }

		public override object EvalValue(Func<string, object> context) {
			List<object> list = GetOperands(context);
			object value = list[0];

			if (value is double) {
				return Math.Floor((double)value);
			} else {
				throw new Exceptions.UnexpectedTypeException(value.GetType());
			}
		}
	}
}
