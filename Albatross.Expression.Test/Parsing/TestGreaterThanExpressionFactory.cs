using Albatross.Expression.Parsing;
using Xunit;

namespace Albatross.Expression.Test.Parsing {
	public class TestGreaterThanExpressionFactory {
		[Theory]
		[InlineData(">", 1)]
		[InlineData(" >", 2)]
		public void GreaterThanExpressionFactory_Success(string text, int expected_next) {
			var factory = new GreaterThanExpressionFactory();
			var result = factory.Parse(text, 0, out var next);
			Assert.NotNull(result);
			Assert.Equal(expected_next, next);
		}

		[Theory]
		[InlineData(">=")]
		[InlineData("=")]
		public void GreaterThanExpressionFactory_Failure(string text) {
			var result = new GreaterThanExpressionFactory().Parse(text, 0, out var next);
			Assert.Null(result);
		}
	}
}