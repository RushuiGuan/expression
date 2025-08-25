using Albatross.Expression.ExpressionFactory;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Xunit;

namespace Albatross.Expression.Test.Parsing {
	public class TestControlTokenParsing {
		[Theory]
		[InlineData('&', "&", 1)]
		[InlineData('&', " &", 2)]
		public void ControlTokenParsing_Success(char token, string text, int expected_next) {
			var result = new ControlTokenFactory(token).Parse(text, 0, out var next);
			Assert.Equal($"{token}", result?.Token);
			Assert.Equal(expected_next, next);
		}

		[Theory]
		[InlineData('(', "a")]
		public void ControlTokenParsing_Failure(char token, string text) {
			var result = new ControlTokenFactory(token).Parse(text, 0, out var next);
			Assert.Equal($"{token}", result?.Token);
		}
	}
}