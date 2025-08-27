using Albatross.Expression.Nodes;
using System.Text.RegularExpressions;

namespace Albatross.Expression.Parsing {
	/// <summary>
	/// Factory class that parses boolean literal expressions from text input.
	/// Recognizes "true" and "false" values with optional case-sensitivity.
	/// </summary>
	public class BooleanLiteralFactory : IExpressionFactory<BooleanLiteral> {
		private readonly bool caseSensitive;
		const string BooleanPattern = @"^\s* (true|false)";

		static readonly Regex caseSensitiveRegex = new Regex(BooleanPattern,
			RegexOptions.Compiled |
			RegexOptions.Singleline |
			RegexOptions.IgnorePatternWhitespace);
		
		static readonly Regex ignoreCaseRegex = new Regex(BooleanPattern,
			RegexOptions.Compiled |
			RegexOptions.Singleline |
			RegexOptions.IgnorePatternWhitespace |
			RegexOptions.IgnoreCase);
		
		/// <summary>
		/// Initializes a new instance of the BooleanLiteralFactory class.
		/// </summary>
		/// <param name="caseSensitive">Whether to perform case-sensitive matching for boolean literals.</param>
		public BooleanLiteralFactory(bool caseSensitive = false) {
			this.caseSensitive = caseSensitive;
		}

		/// <summary>
		/// Attempts to parse a boolean literal from the specified position in the text.
		/// Matches "true" or "false" strings and creates a corresponding BooleanLiteral token.
		/// </summary>
		/// <param name="text">The input text to parse.</param>
		/// <param name="start">The starting position in the text.</param>
		/// <param name="next">When this method returns, contains the next position after the parsed token.</param>
		/// <returns>A BooleanLiteral token if parsing succeeds; otherwise, null.</returns>
		public BooleanLiteral? Parse(string text, int start, out int next) {
			next = text.Length;
			if (start < text.Length) {
				var regex = caseSensitive ? caseSensitiveRegex : ignoreCaseRegex;
				Match match = regex.Match(text.Substring(start));
				if (match.Success) {
					var node = new BooleanLiteral(match.Groups[1].Value);
					next = start + match.Value.Length;
					return node;
				}
			}
			return null;
		}
	}
}