using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using System.Xml;
using Albatross.Expression.Exceptions;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class Minus : InfixOperationToken {
		
		public override string Name { get { return "-"; } }
		public override bool Symbolic { get { return true; } }
		public override int Precedence { get { return 100; } }

		public override object? EvalValue(Func<string, object> context) {
			object a = Operand1.EvalValue(context);
			object b = Operand2.EvalValue(context);

			if (a == null || b == null) {
				return null;
			} else if (a is double && b is double) {
				return (double)a - (double)b;
			} else if (a is DateTime && b is double) {
				return ((DateTime)a).AddDays(-1 * Convert.ToDouble(b));
			}else if(a is DateTime && b is DateTime) {
				return ((DateTime)a - (DateTime)b).TotalSeconds;
			} else {
				throw new UnexpectedTypeException(a.GetType());
			}
		}
	}
}
