using System;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class Positive : UnaryExpression {
		public Positive() : base("+") { }
		public override object Eval(Func<string, object> context) => this.RequiredOperand.Eval(context).ConvertToDouble();
	}
}
