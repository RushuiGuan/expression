﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using System.Xml;
using Albatross.Expression.Exceptions;

using System.Globalization;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class Right : PrefixOperationToken {
		public override string Name { get { return "Right"; } }
		public override int MinOperandCount { get { return 2; } }
		public override int MaxOperandCount { get { return 2; } }
		public override bool Symbolic { get { return false; } }

		public override object? EvalValue(Func<string, object> context) {
			int count;
			List<object> list = GetOperands(context);
			object value = list[1];

			if (value == null) { return list[0]; }

			if (value is double) {
				count = (int)Math.Round((double)value, 0);
			} else {
				throw new Exceptions.UnexpectedTypeException(value.GetType());
			}
			if (count < 0) {
				throw new Exceptions.OperandException("Right function expects a positive number for the second operand");
			}
			string text = Convert.ToString(list[0]);
			if (count > text.Length) {
				return text;
			} else {
				return text.Substring(text.Length - count, count);
			}
		}
	}
}
