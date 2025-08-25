using Albatross.Expression.Parsing;
using Xunit;

namespace Albatross.Expression.Test.Parsing {
	public class TestStringLiteralParsing {

		[Theory]
		[InlineData(" 'xyz'", 6, "'xyz'")]
		[InlineData("'xyz'", 5, "'xyz'")]
		[InlineData("''", 2, "''")]
		[InlineData(@"'\''", 4, @"'\''")]
		[InlineData(@"'\t'", 4, @"'\t'")]
		[InlineData(@"'\\'", 4, @"'\\'")]
		[InlineData(@"'\n'", 4, @"'\n'")]
		public void SingleQuote_StringParsing_Success(string text, int expected_next, string expected_value) {
			new StringLiteralFactory('\'').VerifyValueFactory(text, true, expected_next, expected_value);
		}

		[Theory]
		[InlineData("")]
		[InlineData("'")]
		[InlineData("'\"")]
		public void StringParsing_Failure(string text) {
			new VariableFactory().VerifyValueFactory(text, false, 0, "");
		}
	}
}
