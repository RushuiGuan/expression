using System;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class Minus : InfixExpression {
		public Minus() : base("-", 100) { }

		public override object Eval(Func<string, object> context) {
			var a = RequiredLeft.Eval(context).ConvertToDouble();
			var b = RequiredRight.Eval(context).ConvertToDouble();
			return a - b;
		}
	}
}