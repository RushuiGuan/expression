using Albatross.Expression.Nodes;
using System.Text.RegularExpressions;
using System.Diagnostics.CodeAnalysis;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class LessThan : ComparisonInfixOperation {
		public LessThan() : base("<", 50) { }

		public override bool Interpret(int comparisonResult) {
			return comparisonResult < 0;
		}
	}
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
