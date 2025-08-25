using Albatross.Expression.Parsing;
using Xunit;

namespace Albatross.Expression.Test.Parsing {
	public class TestLessThanExpressionFactory {
		[Theory]
		[InlineData("<", 1)]
		[InlineData(" <", 2)]
		public void LessThanExpressionFactory_Success(string text, int expected_next) {
			var factory = new LessThanExpressionFactory();
			var result = factory.Parse(text, 0, out var next);
			Assert.NotNull(result);
			Assert.Equal(expected_next, next);
		}

		[Theory]
		[InlineData("<=")]
		[InlineData("<>")]
		[InlineData("=")]
		public void LessThanExpressionFactory_Failure(string text) {
			var result = new LessThanExpressionFactory().Parse(text, 0, out var next);
			Assert.Null(result);
		}
	}
}