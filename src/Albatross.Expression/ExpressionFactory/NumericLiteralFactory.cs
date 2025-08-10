using Albatross.Expression.Nodes;
using System.Text.RegularExpressions;

namespace Albatross.Expression.ExpressionFactory {
	// TODO: support culture specific number formats
	public class NumericLiteralFactory : IExpressionFactory<NumericLiteral> {
		const string NumericPattern = @"^\s*([0-9]+(\.[0-9]+)?)";
		public static readonly Regex NumericPatternRegex = new Regex(NumericPattern, 
			RegexOptions.Compiled | 
			RegexOptions.Singleline | 
			RegexOptions.IgnorePatternWhitespace);
		
		public NumericLiteral? Parse(string text, int start, out int next) {
			next = text.Length;
			if (start < text.Length) {
				Match match = NumericPatternRegex.Match(text.Substring(start));
				if (match.Success) {
					var node = new NumericLiteral(match.Groups[1].Value);
					next = start + match.Value.Length;
					return node;
				}
			}
			return null;
		}
	}
}
