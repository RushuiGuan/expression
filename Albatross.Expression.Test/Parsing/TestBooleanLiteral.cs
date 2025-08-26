using Albatross.Expression.Parsing;
using Albatross.Expression.Nodes;
using Xunit;

namespace Albatross.Expression.Test.Parsing {
	public class TestBooleanLiteral {

		[Theory]
		[InlineData(true, "true", 4, "true")]
		[InlineData(true, "false", 5, "false")]

		[InlineData(false, "true", 4, "true")]
		[InlineData(false, "false", 5, "false")]

		[InlineData(false, "TRUE", 4, "TRUE")]
		[InlineData(false, "FALSE", 5, "FALSE")]

		[InlineData(false, " false", 6, "false")]
		[InlineData(false, " false ", 6, "false")]

		[InlineData(false, " FALSE", 6, "FALSE")]
		[InlineData(false, " FALSE ", 6, "FALSE")]
		public void BooleanLiteral_Success_Scenario(bool caseSensitive, string text, int expected_next, string expected_value) {
			new BooleanLiteralFactory(caseSensitive).
			VerifyValueFactory(text, true, expected_next, expected_value);
		}

		[InlineData(false, "")]
		[InlineData(false, " ")]
		[InlineData(false, " f")]
		[InlineData(false, " F")]
		[InlineData(true, "FALSE")]
		[InlineData(true, "TRUE")]
		[Theory]
		public void BooleanLiteral_Fail_Scenario(bool caseSensitive, string text) {
			new BooleanLiteralFactory(caseSensitive).
			VerifyValueFactory(text, false, 0, "");
		}
	}
}