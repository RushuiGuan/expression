using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using System.Xml;
using Albatross.Expression.Exceptions;

using System.Globalization;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class Round : PrefixOperationToken {
		public override string Name { get { return "Round"; } }
		public override int MinOperandCount { get { return 2; } }
		public override int MaxOperandCount { get { return 2; } }
		public override bool Symbolic { get { return false; } }

		public override object EvalValue(Func<string, object> context) {
			List<object> list = GetOperands(context);
			object value = list[0];
			object digit = list[1];

			if (value is double) {
				return Math.Round((double)value,Convert.ToInt32(digit), MidpointRounding.AwayFromZero);
			} else {
				throw new Exceptions.UnexpectedTypeException(value.GetType());
			}
		}
	}
}
