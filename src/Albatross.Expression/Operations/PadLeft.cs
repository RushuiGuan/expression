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
	public class PadLeft : PrefixOperationToken {
		public const char DefaultPaddingCharacter = ' ';

		public override string Name { get { return "PadLeft"; } }
		public override int MinOperandCount { get { return 2; } }
		public override int MaxOperandCount { get { return 3; } }
		public override bool Symbolic { get { return false; } }

		public override object? Eval(Func<string, object> context) {
			int count;
			List<object> list = GetOperands(context);
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
