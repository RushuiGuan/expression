using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using System.Xml;
using Albatross.Expression.Exceptions;

namespace Albatross.Expression.Operations {
	public class Max : PrefixOperationToken {
		
		public override string Name { get { return "max"; } }
		public override int MinOperandCount { get { return 1; } }
		public override int MaxOperandCount { get { return int.MaxValue; } }
		public override bool Symbolic { get { return false; } }


		public override object EvalValue(Func<string, object> context) {
			Type type;
			List<object> list = GetOperands(context, out type);

			if (type == typeof(double)) {
				return Utils.GetMax<double>(list);
			} else if (type == typeof(DateTime)) {
				return Utils.GetMax<DateTime>(list);
			} else if (type == typeof(string)) {
				return Utils.GetMaxString(list);
			} else {
				throw new UnexpectedTypeException(type);
			}
		}

	}
}
