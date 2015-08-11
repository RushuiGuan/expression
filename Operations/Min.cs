using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using System.Xml;
using Albatross.Expression.Exceptions;
using Albatross.Expression.Utils;

namespace Albatross.Expression.Operations {
	public class Min : PrefixOperationToken {

		public override string Name { get { return "min"; } }
		public override int MinOperandCount { get { return 1; } }
		public override int MaxOperandCount { get { return int.MaxValue; } }
		public override bool Symbolic { get { return false; } }

		public override object EvalValue(Func<string, object> context) {
			Type type;
			List<object> list = GetOperands(context, out type);
			if (type == typeof(double)) {
				return Operation.GetMin<double>(list);
			} else if (type == typeof(DateTime)) {
				return Operation.GetMin<DateTime>(list);
			} else if (type == typeof(string)) {
				return Operation.GetMinString(list);
			} else {
				throw new NotSupportedException();
			}
		}
	}
}
