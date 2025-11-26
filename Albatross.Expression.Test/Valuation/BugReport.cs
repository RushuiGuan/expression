using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Albatross.Expression.Test.Valuation {
	public class BugReport {
		[Fact]
		public void RepeatFunction() {
			string expression = "floor(1.2) + floor(2.3)";
			var parser = new Albatross.Expression.Parsing.ParserBuilder().BuildDefault();
			var token = parser.Tokenize(expression);
			var stack = parser.BuildPostfixStack(token);
			var tree = parser.CreateTree(stack);
			var result = tree.Eval(null);
			if (!result.Equals(3.0)) {
				throw new Exception($"Expected 3.0 but got {result}");
			}
		}
	}
}
