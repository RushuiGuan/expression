using System;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class Negative : UnaryExpression  {
		public Negative() : base("-") { }
		
		public override object? Eval(Func<string, object> context) {
			var a = this.Operand.Eval(context);

			if (a is double aa){
				return aa * -1;
			}
			throw new FormatException();
		}
	}
}
