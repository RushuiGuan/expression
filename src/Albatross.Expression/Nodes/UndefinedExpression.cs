using System;

namespace Albatross.Expression.Nodes {
	public class UndefinedExpression : IExpression{
		public string Text() => "undefined";
		public object? Eval(Func<string, object> context) => null;
	}
}