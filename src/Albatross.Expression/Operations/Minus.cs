using System;
using Albatross.Expression.Nodes;
using Albatross.Expression.Exceptions;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class Minus : InfixExpression {
		public Minus() : base("-", 100) { }

		public override object? Eval(Func<string, object> context) {
			object a = Operand1.Eval(context);
			object b = Operand2.Eval(context);

			if (a == null || b == null) {
				return null;
			} else if (a is double && b is double) {
				return (double)a - (double)b;
			} else if (a is System.DateTime && b is double) {
				return ( (System.DateTime)a).AddDays(-1 * Convert.ToDouble(b));
			} else if (a is System.DateTime && b is System.DateTime) {
				return ( (System.DateTime)a - (System.DateTime)b).TotalSeconds;
			} else {
				throw new UnexpectedTypeException(a.GetType());
			}
		}
	}
}