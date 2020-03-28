using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using System.Xml;
using Albatross.Expression.Numeric;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class Positive : PrefixOperationToken {
		private readonly IMultiplyNumber multiplyNumber;

		public Positive(IMultiplyNumber multiplyNumber) {
			this.multiplyNumber = multiplyNumber;
		}

		public override string Name { get { return "+"; } }
		public override int MinOperandCount { get { return 1; } }
		public override int MaxOperandCount { get { return 1; } }
		public override bool Symbolic { get { return true; } }

		public override object EvalValue(Func<string, object> context) {
			object a = Operands.First().EvalValue(context);
			return multiplyNumber.Run(a, 1);
		}
	}
}
