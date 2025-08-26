using System;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Unary {
	public class Positive : UnaryExpression {
		public Positive() : base("+", 250) { }
		protected override object Run(object operand) {
			return operand.ConvertToDouble();
		}
	}
}
