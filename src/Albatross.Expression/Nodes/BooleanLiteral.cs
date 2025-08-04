using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace Albatross.Expression.Nodes {
	/// <summary>
	/// will only take true or false, case insensitive
	/// </summary>
	public class BooleanLiteral : IExpression {
		public BooleanLiteral(string value) {
			this.Value = value;
		}
		public string Value { get; }
		public string Text() => Value;

		public object Eval(Func<string, object> context) {
			bool b;
			if (bool.TryParse(Value, out b)) {
				return b;
			} else {
				throw new FormatException($"Invalid boolean format: {Value}");
			}
		}
	}

	public class BooleanLiteralFactory : IExpressionFactory<BooleanLiteral> {
		const string BooleanPattern = @"^\s* (true|false)";

		static readonly Regex BooleanPatternRegex = new Regex(BooleanPattern,
			RegexOptions.Compiled |
			RegexOptions.Singleline |
			RegexOptions.IgnorePatternWhitespace |
			RegexOptions.IgnoreCase);

		public bool TryParse(string text, int start, out int next, [NotNullWhen(true)] out BooleanLiteral? node) {
			next = text.Length;
			if (start < text.Length) {
				Match match = BooleanPatternRegex.Match(text.Substring(start));
				if (match.Success) {
					node = new BooleanLiteral(match.Groups[1].Value);
					next = start + match.Value.Length;
					return true;
				}
			}
			node = null;
			return false;
		}
	}
}