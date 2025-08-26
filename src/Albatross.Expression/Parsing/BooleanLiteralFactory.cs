using Albatross.Expression.Nodes;
using System.Text.RegularExpressions;

namespace Albatross.Expression.Parsing {
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
		
		public BooleanLiteralFactory(bool caseSensitive = false) {
			this.caseSensitive = caseSensitive;
		}

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