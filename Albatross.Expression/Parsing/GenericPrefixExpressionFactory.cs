using Albatross.Expression.Nodes;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Albatross.Expression.Prefix;

namespace Albatross.Expression.Parsing {
	/// <summary>
	/// Factory for parsing generic prefix expressions by name lookup from a registered collection.
	/// </summary>
	public class GenericPrefixExpressionFactory : IExpressionFactory<IPrefixExpression> {
		private Dictionary<string, Func<IPrefixExpression>> dict;
		
		private static readonly Regex regex = new Regex(@"^\s*([a-zA-Z_][a-zA-Z0-9_]*)\s*(?=\() ", 
			RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);
		
		/// <summary>
		/// Gets the collection of registered prefix expressions by name.
		/// </summary>
		public IReadOnlyDictionary<string, Func<IPrefixExpression>> RegisteredExpressions => dict;
		
		/// <summary>
		/// Initializes a new instance of the <see cref="GenericPrefixExpressionFactory"/> class.
		/// </summary>
		/// <param name="caseSensitive">Whether prefix expression names should be matched case-sensitively.</param>
		public GenericPrefixExpressionFactory(bool caseSensitive = false) {
			if (caseSensitive) {
				dict = new Dictionary<string, Func<IPrefixExpression>>(StringComparer.Ordinal);
			} else {
				dict = new Dictionary<string, Func<IPrefixExpression>>(StringComparer.OrdinalIgnoreCase);
			}
		}

		/// <summary>
		/// Adds a prefix expression to the factory's registered collection.
		/// </summary>
		/// <typeparam name="T">The type of prefix expression to add.</typeparam>
		public void Add<T>() where T : IPrefixExpression, new() {
			var t = new T();
			this.dict.Add(t.Name, ()=> new T());
		}

		public IPrefixExpression? Parse(string text, int start, out int next) {
			next = text.Length;
			if (start < text.Length) {
				Match match = regex.Match(text.Substring(start));
				if (match.Success) {
					var name = match.Groups[1].Value;
					next = start + match.Value.Length;
					if (this.dict.TryGetValue(name, out var func)) {
						return func();
					} else {
						return new PrefixExpression(name, 0, int.MaxValue);
					}
				}
			}
			return null;
		}
	}
}