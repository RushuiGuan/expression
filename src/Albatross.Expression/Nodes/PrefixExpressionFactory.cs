using System;

namespace Albatross.Expression.Nodes {
	public class PrefixExpressionFactory : IExpressionFactory<PrefixExpression> {
		private readonly Func<PrefixExpression> func;
		private readonly string name;
		private readonly bool caseSensitive;

		public PrefixExpressionFactory(Func<PrefixExpression> func, bool caseSensitive = false) {
			this.func = func;
			this.name = func().Name;
			this.caseSensitive = caseSensitive;
		}

		public PrefixExpression? Parse(string text, int start, out int next) {
			next = text.Length;
			if (start < text.Length) {
				while (start < text.Length && char.IsWhiteSpace(text[start])) {
					start++;
				}
				int index = caseSensitive ? text.IndexOf(name, start, StringComparison.Ordinal) 
					: text.IndexOf(name, start, StringComparison.InvariantCultureIgnoreCase);
				if (index == start) {
					//look for a left Parenthesis, but don't consume it
					for (int i = start + name.Length; i < text.Length; i++) {
						var c = text[i];
						if (char.IsWhiteSpace(c)) {
							continue;
						} else if (c == Token.LeftParenthesis) {
							next = start + name.Length;
							return func();
						} else {
							return null;
						}
					}
				}
			}
			return null;
		}
	}
	public class PrefixExpressionFactory<T> : PrefixExpressionFactory where T : PrefixExpression, new() {
		public PrefixExpressionFactory(bool caseSensitive):base(() => new T(), caseSensitive) {
		}
	}
}