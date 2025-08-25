using Albatross.Expression.Parsing;
using Albatross.Expression.Infix;
using Xunit;

namespace Albatross.Expression.Test.Parsing {
	public class TestInfixExpressionFactory {
		[Theory]
		[InlineData(false, "And", 3)]
		[InlineData(false, "and", 3)]
		[InlineData(false, " and", 4)]
		[InlineData(true, "and", 3)]
		[InlineData(false, "anda", 3)]
		public void And_Success(bool caseSensitive, string text, int expected_next) {
			var factory = new InfixExpressionFactory<And>(caseSensitive);
			var result = factory.Parse(text, 0, out var next);
			Assert.NotNull(result);
			Assert.Equal(expected_next, next);
		}

		[Theory]
		[InlineData(false, "aand")]
		public void And_Failure(bool caseSensitive, string text) {
			var result = new InfixExpressionFactory<And>(caseSensitive).Parse(text, 0, out var next);
			Assert.Null(result);
		}
	}
}