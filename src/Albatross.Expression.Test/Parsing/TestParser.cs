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
		[InlineData("1+1", "1+1")]
		public void Run(string text, string parsed) {
			var parser = new ParserBuilder().AddDefault(true).Build();
			var tokens = parser.Tokenize(text);
			var stack = parser.BuildPostfixStack(tokens);
			var tree = parser.CreateTree(stack);
			var expected = tree.Text();
			Assert.Equal(expected, parsed);
		}
	}
}
