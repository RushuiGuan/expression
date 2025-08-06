using System;

namespace Albatross.Expression.Nodes {
	public class Expression : IExpression{
		private readonly string text;

		public Expression(string text) {
			this.text = text;
		}

		public string Text() {
			throw new NotImplementedException();
		}

		public object? Eval(Func<string, object> context) {
			throw new NotImplementedException();
		}
	}
}