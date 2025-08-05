using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Nodes;
using System.Xml;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class Positive : UnaryExpression {
		public Positive() : base("+") { }

		public override object? Eval(Func<string, object> context) {
			var a = this.Operand.Eval(context);
			if (a == null || a is double) { return a; }
			throw new Exceptions.UnexpectedTypeException(a.GetType());
		}
	}
}
