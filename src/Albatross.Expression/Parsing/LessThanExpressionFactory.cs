using System.Text.RegularExpressions;
using Albatross.Expression.Infix;

namespace Albatross.Expression.Parsing {
	/// <summary>
	/// Instead of using infix operator parser, regex is used to match the operator to avoid ambiguity with other operators like &lt;= and &lt;&gt;
	/// </summary>
	public class LessThanExpressionFactory : IExpressionFactory<LessThan> {
		const string Pattern = @"^\s*(\<)(?![=\>])";
		static Regex regex = new Regex(Pattern, RegexOptions.Singleline | RegexOptions.Compiled);

		public LessThan? Parse(string text, int start, out int next) {
			next = text.Length;
			if (start < text.Length) {
				Match match = regex.Match(text.Substring(start));
				if (match.Success) {
					next = start + match.Value.Length;
					return new LessThan();
				}
			}
			return null;
		}
	}
}
