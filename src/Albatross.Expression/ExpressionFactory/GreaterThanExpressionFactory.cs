using Albatross.Expression.InfixOperations;
using System.Text.RegularExpressions;

namespace Albatross.Expression.ExpressionFactory {
	public class GreaterThanExpressionFactory : IExpressionFactory<GreaterThan> {
		const string Pattern = @"^\s*(\>)(?!=)";
		static readonly Regex regex = new Regex(Pattern, RegexOptions.Compiled | RegexOptions.Singleline);

		public GreaterThan? Parse(string text, int start, out int next) {
			next = text.Length;
			if (start < text.Length) {
				Match match = regex.Match(text.Substring(start));
				if (match.Success) {
					next = start + match.Value.Length;
					return new GreaterThan();
				}
			}
			return null;
		}
	}
}