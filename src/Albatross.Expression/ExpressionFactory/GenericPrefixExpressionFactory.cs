using Albatross.Expression.Nodes;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Albatross.Expression.PrefixOperations;

namespace Albatross.Expression.ExpressionFactory {
	public class GenericPrefixExpressionFactory : IExpressionFactory<IPrefixExpression> {
		private Dictionary<string, IPrefixExpression> dict;
		/// <summary>
		/// TODO: the left parathesis should be a look ahead.  it should not be consumed
		/// </summary>
		private static readonly Regex regex = new Regex(@"^\s*([a-zA-Z_][a-zA-Z0-9_]*)\s*(?=\() ", 
			RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);
		
		public IReadOnlyDictionary<string, IPrefixExpression> RegisteredExpressions => dict;
		
		public GenericPrefixExpressionFactory(bool caseSensitive = false) {
			if (caseSensitive) {
				dict = new Dictionary<string, IPrefixExpression>(StringComparer.Ordinal);
			} else {
				dict = new Dictionary<string, IPrefixExpression>(StringComparer.OrdinalIgnoreCase);
			}
		}

		public void Add<T>(T t) where T : IPrefixExpression {
			this.dict.Add(t.Name, t);
		}

		public IPrefixExpression? Parse(string text, int start, out int next) {
			next = text.Length;
			if (start < text.Length) {
				Match match = regex.Match(text.Substring(start));
				if (match.Success) {
					var name = match.Groups[1].Value;
					next = start + match.Value.Length;
					if (this.dict.TryGetValue(name, out var expression)) {
						return expression;
					} else {
						return new PrefixExpression(name, 0, int.MaxValue);
					}
				}
			}
			return null;
		}
	}
}