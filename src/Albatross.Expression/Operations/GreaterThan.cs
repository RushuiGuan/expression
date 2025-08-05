using Albatross.Expression.Nodes;
using System.Text.RegularExpressions;
using System.Diagnostics.CodeAnalysis;

namespace Albatross.Expression.Operations {
	/// <summary>
	/// <para>Infix GreaterThan operation.</para>
	/// <para>Operand Count: 2</para>
	/// <list type="number">
	///		<listheader>
	///		<description>Operands</description>
	///		</listheader>
	///		<item><description>Operand1 : any</description></item>
	///		<item><description>Operand2 : any</description></item>
	/// </list>
	/// 
	/// <para>Output Type: Boolean</para>
	/// <para>Usage: 3 > 2</para>
	/// <para>Precedance: 50</para>
	/// </summary>
	[ParserOperation]
	public class GreaterThan : ComparisonInfixOperation {
		public override string Operator { get { return ">"; } }
		public override int Precedence { get { return 50; } }

		public override bool interpret(int comparisonResult) {
			return comparisonResult > 0;
		}
	}

	public class GreaterThanExpressionFactory : IExpressionFactory<GreaterThan> {
		const string Pattern = @"^\s*(\>)(?!=)";
		static Regex regex = new Regex(Pattern, RegexOptions.Compiled | RegexOptions.Singleline);

		public bool TryParse(string text, int start, out int next, [NotNullWhen(true)] out GreaterThan? node) {
			next = text.Length;
			if (start < text.Length) {
				Match match = regex.Match(text.Substring(start));
				if (match.Success) {
					next = start + match.Value.Length;
					node = new GreaterThan();
					return true;
				}
			}
			node = null;
			return false;
		}
	}
}
