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
			double d;
			if (double.TryParse(Value, out d)) {
				return d;
			} else {
				throw new FormatException($"Invalid numeric format: {Value}");
			}
		}
	}
	public class NumericLiteralFactory : IExpressionFactory<NumericLiteral> {
		const string NumericPattern = @"^\s*([0-9]*\.?[0-9]+)";
		static readonly Regex NumericPatternRegex = new Regex(NumericPattern, 
			RegexOptions.Compiled | 
			RegexOptions.Singleline | 
			RegexOptions.IgnorePatternWhitespace | 
			RegexOptions.IgnoreCase);
		
		public bool TryParse(string text, int start, out int next, [NotNullWhen(true)] out NumericLiteral? node) {
			next = text.Length;
			if (start < text.Length) {
				Match match = NumericPatternRegex.Match(text.Substring(start));
				if (match.Success) {
					node = new NumericLiteral(match.Groups[1].Value);
					next = start + match.Value.Length;
					return true;
				}
			}
			node = null;
			return false;
		}
	}
}
