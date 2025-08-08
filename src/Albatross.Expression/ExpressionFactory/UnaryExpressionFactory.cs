using Albatross.Expression.Nodes;
using System;

namespace Albatross.Expression.ExpressionFactory {
	public class UnaryExpressionFactory<T> : IExpressionFactory<T> where T : class, IUnaryExpression, new() {
		private readonly string name;

		public UnaryExpressionFactory(string name) {
			this.name = name;
		}

		public T? Parse(string expression, int start, out int next) {
			next = expression.Length;
			if (start < expression.Length) {
				while (start < expression.Length && char.IsWhiteSpace(expression[start])) {
					start++;
				}
				var index = expression.IndexOf(name, start, StringComparison.Ordinal); 
				if (index == start) {
					next = start + name.Length;
					return new T();
				}
			}
			return null;
		}
	}
}