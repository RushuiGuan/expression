using Albatross.Expression.ExpressionFactory;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Xunit;

namespace Albatross.Expression.Test.Parsing {
	public class TestControlTokenParsing {
		[Theory]
		[InlineData('&', "&", 1)]
		[InlineData('&', " &", 2)]
		public void ControlTokenParsing_Success(char token, string text, int expected_next) {
			new ControlTokenFactory(token).VerifyValueFactory(text, true, expected_next, $"{token}");
		}

		[Theory]
		[InlineData('(', "a")]
		public void ControlTokenParsing_Failure(char token, string text) {
			new ControlTokenFactory(token).VerifyValueFactory(text, false, 0, "");
		}
	}
}
