using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using System.Xml;
using Albatross.Expression.Exceptions;
using Albatross.Expression.Numeric;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class Minus : InfixOperationToken {
		private readonly ISubtractNumber subtractNumber;

		public Minus(ISubtractNumber subtractNumber) {
			this.subtractNumber = subtractNumber;
		}

		public override string Name { get { return "-"; } }
		public override bool Symbolic { get { return true; } }
		public override int Precedence { get { return 100; } }

		public override object EvalValue(Func<string, object> context) {
			object a = Operand1.EvalValue(context);
			object b = Operand2.EvalValue(context);
			return this.subtractNumber.Run(a, b);
		}
	}
}
