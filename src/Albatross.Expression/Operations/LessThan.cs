using Albatross.Expression.Nodes;
using System.Text.RegularExpressions;
using System.Diagnostics.CodeAnalysis;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class LessThan : ComparisonInfixOperation {
		public override string Operator { get { return "<"; } }
		public override bool Symbolic { get { return true; } }
		public override int Precedence { get { return 50; } }

		public override bool interpret(int comparisonResult) {
			return comparisonResult < 0;
		}
	}
	/// <summary>
	/// Instead of using infix operator parser, regex is used to match the operator to avoid ambiguity with other operators like &lt;= and &lt;&gt;
	/// </summary>
	public class LessThanExpressionFactory : IExpressionFactory<LessThan> {
		const string Pattern = @"^\s*(\<)(?![=\>])";
		static Regex regex = new Regex(Pattern, RegexOptions.Singleline | RegexOptions.Compiled);

		public bool TryParse(string text, int start, out int next, [NotNullWhen(true)] out LessThan? node) {
			next = text.Length;
			if (start < text.Length) {
				Match match = regex.Match(text.Substring(start));
				if (match.Success) {
					next = start + match.Value.Length;
					node = new LessThan();
					return true;
				}
			}
			node = null;
			return false;
		}
	}
}
