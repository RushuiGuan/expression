using System;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class Negative : UnaryExpression {
		public Negative() : base("-") { }

		public override object? Eval(Func<string, object> context) {
			var a = this.Operand.Eval(context).ConvertToDouble();
			return a * -1;
		}
	}
}