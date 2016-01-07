using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using System.Xml;
using Albatross.Expression.Exceptions;


namespace Albatross.Expression.Operations {
	public class If : PrefixOperationToken {

		public override string Name { get { return "If"; } }
		public override int MinOperandCount { get { return 2; } }
		public override int MaxOperandCount { get { return 3; } }
		public override bool Symbolic { get { return false; } }


		public override object EvalValue(Func<string, object> context) {
			object obj = Operands.First().EvalValue(context);

			if (Utils.GetLogicalValue(obj)) {
				return Operands[1].EvalValue(context);
			} else {
				if (Operands.Count >= 3) {
					return Operands[2].EvalValue(context);
				} else {
					return null;
				}
			}
		}
	}
}
