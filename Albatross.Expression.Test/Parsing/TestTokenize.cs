using Albatross.Expression.Parsing;
using Xunit;

namespace Albatross.Expression.Test.Parsing {
	public class TestTokenize {
		[Theory]
		[InlineData("1+1", "1 + 1")]
		[InlineData("1 * (2 - 3)", "1 * ( 2 - 3 )")]
		public void Run(string text, string expected) {
			var parser = new ParserBuilder().BuildDefault(true);
			var tokens = parser.Tokenize(text);
			var expectedTokens = expected.Split(' ');
			Assert.Equivalent(expectedTokens, tokens.Select(x => x.Token).ToArray());
		}
	}
}