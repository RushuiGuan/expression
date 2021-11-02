using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using System.Xml;

using Albatross.Expression.Documentation.Attributes;
using System.Text.RegularExpressions;

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
	[OperationDoc(Documentation.Group.Boolean, "@o1 {token} @o2",
		@"
### Returns true if the first numeric value is greater than the second numeric value. 

#### References:
- [{token}](https://help.workiom.com/article/formula#{token})
        ",
		@"
5 {token} 3
        "
	)]
	[ParserOperation]
	public class GreaterThan : ComparisonInfixOperation {
		const string Pattern = @"^\s*(\>)(?!=)";
		static Regex regex = new Regex(Pattern, RegexOptions.Compiled | RegexOptions.Singleline);

		public override string Name { get { return ">"; } }
		public override bool Symbolic { get { return true; } }
		public override int Precedence { get { return 50; } }

		public override bool interpret(int comparisonResult) {
			return comparisonResult > 0;
		}
		public override bool Match(string expression, int start, out int next) {
			next = expression.Length;
			if (start < expression.Length) {
				Match match = regex.Match(expression.Substring(start));
				if (match.Success) {
					next = start + match.Value.Length;
					return true;
				}
			}
			return false;
		}
	}
}
