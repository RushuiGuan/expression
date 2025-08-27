using Albatross.Expression.Infix;
using System.Text.RegularExpressions;

namespace Albatross.Expression.Parsing {
	/// <summary>
	/// Factory class that parses greater-than comparison operators from text input.
	/// Recognizes the ">" operator but excludes ">=" to avoid conflicts.
	/// </summary>
	public class GreaterThanExpressionFactory : IExpressionFactory<GreaterThan> {
		const string Pattern = @"^\s*(\>)(?!=)";
		static readonly Regex regex = new Regex(Pattern, RegexOptions.Compiled | RegexOptions.Singleline);

		/// <summary>
		/// Attempts to parse a greater-than operator from the specified position in the text.
		/// Uses a negative lookahead to ensure it doesn't match ">=" operators.
		/// </summary>
		/// <param name="text">The input text to parse.</param>
		/// <param name="start">The starting position in the text.</param>
		/// <param name="next">When this method returns, contains the next position after the parsed operator.</param>
		/// <returns>A GreaterThan infix expression if parsing succeeds; otherwise, null.</returns>
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