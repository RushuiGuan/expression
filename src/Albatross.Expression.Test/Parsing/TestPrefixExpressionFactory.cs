using Albatross.Expression.ExpressionFactory;
using Albatross.Expression.PrefixOperations;
using Xunit;

namespace Albatross.Expression.Test.Parsing {
	public class TestPrefixExpressionFactory {
		[Theory]
		[InlineData(false, "a()", "a", 1, "a")]
		[InlineData(false, "ab()", "ab", 2, "ab")]
		[InlineData(true, "ab()", "ab", 2, "ab")]
		public void PrefixExpression_Success(bool caseSensitive, string text, string name, int expected_next, string expected_name) {
			var factory = new PrefixExpressionFactory(() => new PrefixExpression(name, 0, 0), caseSensitive);
			var result = factory.Parse(text, 0, out var next);
			Assert.NotNull(result);
			Assert.Equal(expected_next, next);
			Assert.Equal(expected_name, result.Name);
		}
		[Theory]
		[InlineData("a1", false, "a()")]
		[InlineData("xx", false, "xxx()")]
		[InlineData("test", false, "test")]
		[InlineData("", false, "")]
		[InlineData("test", true, "Test()")]
		public void PrefixExpression_Failure(string name, bool caseSensitive, string text) {
			var factory = new PrefixExpressionFactory(() => new PrefixExpression(name, 0, 0), caseSensitive);
			var result = factory.Parse(text, 0, out var next);
			Assert.Null(result);
		}
	}
}
