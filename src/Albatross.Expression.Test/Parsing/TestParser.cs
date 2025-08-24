using Albatross.Expression.ExpressionFactory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Albatross.Expression.Test.Parsing {
	public class TestParser {
		[Theory]
		[InlineData("1+2", "+ 2 1")]
		public void VerifyPostfixStack(string text, string expected) {
			var parser = new ParserBuilder().AddDefault(true).Build();
			var tokens = parser.Tokenize(text);
			var stack = parser.BuildPostfixStack(tokens);
			Assert.Equal(expected, string.Join(' ', stack.Select(x => x.Token)));
		}
	}
}