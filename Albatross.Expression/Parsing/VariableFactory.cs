using Albatross.Expression.Nodes;
using System.Text.RegularExpressions;

namespace Albatross.Expression.Parsing {
	/// <summary>
	/// Factory for parsing variable name tokens from expression text.
	/// </summary>
	public class VariableFactory : IExpressionFactory<Variable> {
		const string VariableNamePattern = @"^\s*([a-zA-Z_][a-zA-Z0-9_]*(\.[a-zA-Z_][a-zA-Z0-9_]*)?) \b (?!\s*\() ";
		
		/// <summary>
		/// Compiled regex pattern for matching variable names (supports dot notation like "obj.prop").
		/// </summary>
		public static readonly Regex VariableNameRegex = new Regex(VariableNamePattern, RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);


		public Variable? Parse(string expression, int start, out int next) {
			next = expression.Length;
			if (start < expression.Length) {
				Match match = VariableNameRegex.Match(expression.Substring(start));
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