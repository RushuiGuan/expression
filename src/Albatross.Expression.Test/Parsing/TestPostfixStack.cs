using Albatross.Expression.ExpressionFactory;
using Xunit;

namespace Albatross.Expression.Test.Parsing {
	public class TestPostfixStack {
		[Theory]
		[InlineData("1+2", "+ 2 1")]
		[InlineData("1+test(2)", "+ 2 1")]
		public void Run(string text, string expected) {
			var parser = new ParserBuilder().AddDefault(true).Build();
			var tokens = parser.Tokenize(text);
			var stack = parser.BuildPostfixStack(tokens);
			Assert.Equal(expected, string.Join(' ', stack.Select(x => x.Token)));
		}
	}
}