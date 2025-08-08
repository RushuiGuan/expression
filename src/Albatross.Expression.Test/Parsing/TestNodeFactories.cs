using Albatross.Expression.ExpressionFactory;
using Xunit;

namespace Albatross.Expression.Test.Parsing {
	public class TestNodeFactories {

		[Theory]
		[InlineData(false, "", false, 0, "")]
		[InlineData(false, "     ", false, 5, "")]
		[InlineData(false, "true", true, 4, "true")]
		[InlineData(false, "false", true, 5, "false")]
		[InlineData(false, " false", true, 6, "false")]
		[InlineData(false, " false ", true, 6, "false")]
		[InlineData(false, " f", false, 2, "")]


		[InlineData(false, "True", true, 4, "true")]
		[InlineData(false, "False", true, 5, "false")]
		[InlineData(false, " False", true, 6, "false")]
		[InlineData(false, " False ", true, 6, "false")]
		[InlineData(false, " F", false, 2, "")]
		public void TestBooleanLiteralFactory(bool caseSensitive, string text, bool parsed, int expected_next, string expected_value) {
			var factory = new BooleanLiteralFactory(caseSensitive);
			var result = factory.Parse(text, 0, out var next);
			if (parsed) {
				Assert.NotNull(result);
				Assert.Equal(expected_value, result.Value);
			} else {
				Assert.Null(result);
			}
			Assert.Equal(expected_next, next);
		}
	}
}
