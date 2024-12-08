﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using System.Xml;
using Albatross.Expression.Exceptions;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class Now : PrefixOperationToken {

		public override string Name { get { return "Now"; } }
		public override int MinOperandCount { get { return 0; } }
		public override int MaxOperandCount { get { return 0; } }
		public override bool Symbolic { get { return false; } }

		public override object? EvalValue(Func<string, object> context) {
			return DateTime.Now;
		}
	}
}
