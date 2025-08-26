using Albatross.Expression.Parsing;
using Albatross.Expression.Prefix;
using Xunit;

namespace Albatross.Expression.Test.Parsing {
	public class TestGenericPrefixExpressionFactory {
		[Theory]
		[InlineData("_a()", "_a")]
		[InlineData("a()", "a")]
		[InlineData("ab()", "ab")]
		[InlineData(" ab()", "ab")]
		[InlineData("ab1()", "ab1")]
		[InlineData("ab(", "ab")]
		public void PrefixExpression_Success(string text, string expected_name) {
			var factory = new GenericPrefixExpressionFactory(false);
			var result = factory.Parse(text, 0, out var next);
			Assert.NotNull(result);
			var expected_next = text.IndexOf('(');
			Assert.Equal(expected_next, next);
			Assert.Equal(expected_name, result.Name);
		}

		[Theory]
		[InlineData("1a()")]
		[InlineData("a.b()")]
		[InlineData("xxx#()")]
		[InlineData("test")]
		[InlineData("")]
		public void PrefixExpression_Failure(string text) {
			var factory = new GenericPrefixExpressionFactory(false);
			var result = factory.Parse(text, 0, out var next);
			Assert.Null(result);
		}
	}
}