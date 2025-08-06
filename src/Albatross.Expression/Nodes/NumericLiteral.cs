using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace Albatross.Expression.Nodes {
	/// <summary>
	/// will take any numbers with decimals and without signs.
	/// </summary>
	public class NumericLiteral : IExpression {
		public NumericLiteral(string value) {
			Value = value;
		}
		public string Value { get; }
		public string Text() => Value;

		public object Eval(Func<string, object> context) {
			if (double.TryParse(Value, out var d)) {
				return d;
			} else {
				throw new FormatException($"Invalid numeric format: {Value}");
			}
		}
	}
	// TODO: support culture specific number formats
	public class NumericLiteralFactory : IExpressionFactory<NumericLiteral> {
		const string NumericPattern = @"^\s*([0-9]*\.?[0-9]+)";
		static readonly Regex numericPatternRegex = new Regex(NumericPattern, 
			RegexOptions.Compiled | 
			RegexOptions.Singleline | 
			RegexOptions.IgnorePatternWhitespace | 
			RegexOptions.IgnoreCase);
		
		public NumericLiteral? Parse(string text, int start, out int next) {
			next = text.Length;
			if (start < text.Length) {
				Match match = numericPatternRegex.Match(text.Substring(start));
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
