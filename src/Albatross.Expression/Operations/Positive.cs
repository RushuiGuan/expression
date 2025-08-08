using System;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class Positive : UnaryExpression {
		public Positive() : base("+") { }
		public override object Run(object operand) {
			return operand.ConvertToDouble();
		}
	}
}
