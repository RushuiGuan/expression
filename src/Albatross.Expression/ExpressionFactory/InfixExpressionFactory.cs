using Albatross.Expression.Nodes;
using System;

namespace Albatross.Expression.ExpressionFactory {
	public class InfixExpressionFactory<T> : IExpressionFactory<T> where T : class, IInfixExpression, new() {
		private readonly bool caseSensitive;

		public InfixExpressionFactory(bool caseSensitive) {
			this.caseSensitive = caseSensitive;
		}

		public T? Parse(string text, int start, out int next) {
			next = text.Length;
			if (start < text.Length) {
				while (start < text.Length && char.IsWhiteSpace(text[start])) {
					start++;
				}
				var t = new T();
				var index = caseSensitive
					? text.IndexOf(t.Operator, start, StringComparison.Ordinal)
					: text.IndexOf(t.Operator, start, StringComparison.InvariantCultureIgnoreCase);
				if (index == start) {
					next = start + t.Operator.Length;
					return t;
				}
			}
			return null;
		}
	}
}