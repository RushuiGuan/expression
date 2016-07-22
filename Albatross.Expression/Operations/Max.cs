using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using System.Xml;
using Albatross.Expression.Exceptions;
using System.Collections;

namespace Albatross.Expression.Operations {
	public class Max : PrefixOperationToken {
		
		public override string Name { get { return "max"; } }
		public override int MinOperandCount { get { return 0; } }
		public override int MaxOperandCount { get { return int.MaxValue; } }
		public override bool Symbolic { get { return false; } }


		public override object EvalValue(Func<string, object> context) {
			if (Operands.Count == 0) { return null; }
			Type type;
			IEnumerable list = GetParamsOperands(context, out type);

			if (type == null) {
				return null;
			} else if (type == typeof(double)) {
				return ParserUtils.GetMax<double>(list);
			} else if (type == typeof(DateTime)) {
				return ParserUtils.GetMax<DateTime>(list);
			} else if (type == typeof(string)) {
				return ParserUtils.GetMaxString(list);
			} else {
				throw new UnexpectedTypeException(type);
			}
		}
	}
}
