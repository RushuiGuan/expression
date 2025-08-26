using Albatross.Expression.Parsing;
using Albatross.Expression.Nodes;
using Xunit;

namespace Albatross.Expression.Test.Parsing {
	public class TestNumericLiteral {
		[Theory]
		[InlineData("1", 1, "1")]
		[InlineData(" 1", 2, "1")]
		[InlineData(" 1 ", 2, "1")]
		[InlineData("1+1", 1, "1")]
		[InlineData("1.0", 3, "1.0")]
		[InlineData("0.1", 3, "0.1")]
		[InlineData("1.", 1, "1")]
		public void NumericLiteral_Success(string text, int expected_next, string expected_value) {
			new NumericLiteralFactory().
			VerifyValueFactory(text, true, expected_next, expected_value);
		}

		[Theory]
		[InlineData("-1")]
		[InlineData("")]
		[InlineData(" ")]
		[InlineData("a")]
		[InlineData(".1")]
		// [InlineData("1.")]  this will not fail, instead it would match 1
		[InlineData(".")]
		public void NumericLiteral_Failure(string text) {
			new NumericLiteralFactory().
			VerifyValueFactory(text, false, 0, "");
		}
	}
}
