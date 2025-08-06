using System;
using System.Collections.Generic;
using System.Linq;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class PadLeft : PrefixExpression {
		public const char DefaultPaddingCharacter = ' ';
		public PadLeft() : base("PadLeft", 2, 3) { }

		public override object? Eval(Func<string, object> context) {
			int count;
			List<object> list = GetRequiredOperandValues(context);
			object value = list[1];

			if (value == null) { return list[0]; }

			if (value is double) {
				count = (int)Math.Round((double)value, 0);
			} else {
				throw new Exceptions.UnexpectedTypeException(value.GetType());
			}
			char paddingChar;
			if (list.Count == 2 || string.IsNullOrEmpty(Convert.ToString(list[2]))) {
				paddingChar = DefaultPaddingCharacter;
			} else {
				paddingChar = Convert.ToString(list[2]).First();
			}

			return Convert.ToString(list[0]).PadLeft(count, paddingChar);
		}
	}
}
