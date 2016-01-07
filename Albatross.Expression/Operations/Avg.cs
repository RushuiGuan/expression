using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using System.Xml;
using Albatross.Expression.Exceptions;


namespace Albatross.Expression.Operations {
	public class Avg : PrefixOperationToken {

		public override string Name { get { return "avg"; } }
		public override int MinOperandCount { get { return 1; } }
		public override int MaxOperandCount { get { return int.MaxValue; } }
		public override bool Symbolic { get { return false; } }

		public override object EvalValue(Func<string, object> context) {
			List<double?> list = GetOperands<double?>(context);
			double sum = 0;
			int count = 0;
			foreach (double? d in list) {
				if (d.HasValue) {
					sum += d.Value;
					count++;
				}
			}
			if (count != 0) {
				return sum / count;
			} else {
				return null;
			}
		}
	}
}
