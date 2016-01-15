using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using System.Xml;
using Albatross.Expression.Exceptions;
using System.Collections;

namespace Albatross.Expression.Operations {
	public class Min : PrefixOperationToken {

		public override string Name { get { return "min"; } }
		public override int MinOperandCount { get { return 0; } }
		public override int MaxOperandCount { get { return int.MaxValue; } }
		public override bool Symbolic { get { return false; } }

		public override object EvalValue(Func<string, object> context) {
			Type type;
			IEnumerable items = GetParamsOperands(context, out type);

			if (type == null) {
				return null;
			}else if (type == typeof(double)) {
				return Utils.GetMin<double>(items);
			} else if (type == typeof(DateTime)) {
				return Utils.GetMin<DateTime>(items);
			} else if (type == typeof(string)) {
				return Utils.GetMinString(items);
			} else {
				throw new UnexpectedTypeException(type);
			}
		}
	}
}
