using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using System.Xml;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class Or : InfixOperationToken {
		
		public override string Name { get { return "or"; } }
		public override bool Symbolic { get { return true; } }
		public override int Precedence { get { return 20; } }

		public override object EvalValue(Func<string, object> context) {
			object value = Operand1.EvalValue(context);
			if (value.ConvertToBoolean()) {
				return true;
			} else {
				value = Operand2.EvalValue(context);
				return value.ConvertToBoolean();
			}
		}
	}
}
