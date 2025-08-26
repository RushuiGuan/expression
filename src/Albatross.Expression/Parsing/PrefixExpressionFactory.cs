using Albatross.Expression.Nodes;
using System;

namespace Albatross.Expression.Parsing {
	/// <summary>
	/// Factory for creating prefix expressions using a provided factory function.
	/// </summary>
	public class PrefixExpressionFactory : IExpressionFactory<IPrefixExpression> {
		private readonly Func<IPrefixExpression> func;
		private readonly string name;
		private readonly bool caseSensitive;

		/// <summary>
		/// Initializes a new instance of the <see cref="PrefixExpressionFactory"/> class.
		/// </summary>
		/// <param name="func">Function that creates instances of the prefix expression.</param>
		/// <param name="caseSensitive">Whether function name matching should be case-sensitive.</param>
		public PrefixExpressionFactory(Func<IPrefixExpression> func, bool caseSensitive = false) {
			this.func = func;
			name = func().Name;
			this.caseSensitive = caseSensitive;
		}

		public IPrefixExpression? Parse(string text, int start, out int next) {
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
						} else if (c == ControlTokenFactory.LeftParenthesisChar) {
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
	public class PrefixExpressionFactory<T> : PrefixExpressionFactory where T : IPrefixExpression, new() {
		public PrefixExpressionFactory(bool caseSensitive):base(() => new T(), caseSensitive) {
		}
	}
}