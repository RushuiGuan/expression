using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using System.Xml;
using System.Text.RegularExpressions;
using Albatross.Expression.Documentation.Attributes;

namespace Albatross.Expression.Operations {
	[OperationDoc(Documentation.Group.Boolean, "@o1 {token} @o2",
		@"
### Returns true if the first numeric value is less than the second numeric value. 

#### References:
- [{token}](https://help.workiom.com/article/formula#{token})
        ",
		@"
5 {token} 3
        "
	)]
	[ParserOperation]
	public class LessThan : ComparisonInfixOperation {
		const string Pattern = @"^\s*(\<)(?![=\>])";
		static Regex regex = new Regex(Pattern, RegexOptions.Singleline| RegexOptions.Compiled);

		public override string Name { get { return "<"; } }
		public override bool Symbolic { get { return true; } }
		public override int Precedence { get { return 50; } }

		public override bool interpret(int comparisonResult) {
			return comparisonResult < 0;
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
