using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using System.Xml;
using Albatross.Expression.Exceptions;
using System.Collections;


namespace Albatross.Expression.Operations {
	public class Avg : PrefixOperationToken {

		public override string Name { get { return "avg"; } }
		public override int MinOperandCount { get { return 0; } }
		public override int MaxOperandCount { get { return int.MaxValue; } }
		public override bool Symbolic { get { return false; } }

		public override object EvalValue(Func<string, object> context) {
			if (Operands.Count == 0) { return null; }
			Type type;
			IEnumerable items = GetParamsOperands(context, out type);
			
			double sum = 0;
			int count = 0;

			try {
				foreach (double? item in items) {
					if (item != null) {
						sum += (double)item;
						count++;
					}
				}
			} catch (InvalidCastException) {
				throw new UnexpectedTypeException();
			}
			if (count != 0) {
				return sum / count;
			} else {
				return null;
			}
		}
	}
}
