using Albatross.Expression.Nodes;
using System;

namespace Albatross.Expression.Parsing {
	/// <summary>
	/// Generic factory for creating unary expression instances by matching their operator tokens.
	/// </summary>
	/// <typeparam name="T">The type of unary expression to create.</typeparam>
	public class UnaryExpressionFactory<T> : IExpressionFactory<T> where T : class, IUnaryExpression, new() {
		public T? Parse(string expression, int start, out int next) {
			next = expression.Length;
			if (start < expression.Length) {
				while (start < expression.Length && char.IsWhiteSpace(expression[start])) {
					start++;
				}
				var t = new T();
				var index = expression.IndexOf(t.Operator, start, StringComparison.Ordinal); 
				if (index == start) {
					next = start + t.Operator.Length;
					return new T();
				}
			}
			return null;
		}
	}
}