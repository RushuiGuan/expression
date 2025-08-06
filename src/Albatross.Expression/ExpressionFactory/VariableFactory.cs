using Albatross.Expression.Nodes;
using System.Text.RegularExpressions;

namespace Albatross.Expression.ExpressionFactory {
	public class VariableFactory : IExpressionFactory<Variable> {
		private readonly bool caseSensitive;

		//const string VariableNamePattern = @"^\s*([a-zA-Z_]+\.?[a-zA-Z0-9_]*) \b (?!\s*\() ";
		const string VariableNamePattern = @"^\s*([a-zA-Z_][a-zA-Z0-9_]*(\.[a-zA-Z_][a-zA-Z0-9_]*)?) \b (?!\s*\() ";
		static readonly Regex caseSensitiveVariableNameRegex = new Regex(VariableNamePattern, RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);
		static readonly Regex caseInsensitiveVariableNameRegex = new Regex(VariableNamePattern, RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase);

		public VariableFactory(bool caseSensitive) {
			this.caseSensitive = caseSensitive;
		}

		public Variable? Parse(string expression, int start, out int next) {
			next = expression.Length;
			if (start < expression.Length) {
				Match match = caseSensitive
					? caseSensitiveVariableNameRegex.Match(expression.Substring(start))
					: caseInsensitiveVariableNameRegex.Match(expression.Substring(start));
				if (match.Success) {
					var node = new Variable(match.Groups[1].Value);
					next = start + match.Value.Length;
					return node;
				}
			}
			return null;
		}
	}
}