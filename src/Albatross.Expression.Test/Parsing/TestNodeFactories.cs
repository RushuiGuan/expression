using Albatross.Expression.ExpressionFactory;
using Albatross.Expression.Nodes;
using Xunit;

namespace Albatross.Expression.Test.Parsing {
	public class TestValueFactories {

		[Theory]
		[InlineData(false, "", false, 0, "")]
		[InlineData(false, "     ", false, 5, "")]
		[InlineData(false, "true", true, 4, "true")]
		[InlineData(false, "false", true, 5, "false")]
		[InlineData(false, " false", true, 6, "false")]
		[InlineData(false, " false ", true, 6, "false")]
		[InlineData(false, " f", false, 2, "")]

		[InlineData(false, "True", true, 4, "True")]
		[InlineData(false, "False", true, 5, "False")]
		[InlineData(false, " False", true, 6, "False")]
		[InlineData(false, " False ", true, 6, "False")]
		[InlineData(false, " F", false, 2, "")]

		[InlineData(true, "False", false, 5, "")]
		[InlineData(true, "false", true, 5, "false")]
		[InlineData(true, "True", false, 4, "True")]
		[InlineData(true, "true", true, 4, "true")]

		[InlineData(true, "true+1", true, 4, "true")]
		public void TestBooleanLiteralFactory(bool caseSensitive, string text, bool parsed, int expected_next, string expected_value) {
			var factory = new BooleanLiteralFactory(caseSensitive);
			VerifyValueFactory(text, factory, parsed, expected_next, expected_value);
		}

		[Theory]
		[InlineData("", false, 0, "")]
		[InlineData(" ", false, 1, "")]
		[InlineData("1", true, 1, "1")]
		[InlineData(" 1", true, 2, "1")]
		[InlineData(" 1 ", true, 2, "1")]
		[InlineData("1+1", true, 1, "1")]
		[InlineData("-1", false, 2, "")]
		public void TestNumericLiteralFactory(string text, bool parsed, int expected_next, string expected_value) {
			var factory = new NumericLiteralFactory();
			VerifyValueFactory(text, factory, parsed, expected_next, expected_value);
		}

		[Theory]
		[InlineData("", false, 0, "")]
		[InlineData("a", true, 1, "a")]
		[InlineData("a+b", true, 1, "a")]
		[InlineData("a.b", true, 3, "a.b")]
		[InlineData("a.b.c", false, 5, "")]
		[InlineData("_a", true, 2, "_a")]
		[InlineData("_", true, 1, "_")]
		[InlineData("a1", true, 2, "a1")]
		[InlineData("1a", false, 2, "")]
		// old test case
		[InlineData("a+b+c+d", true, 1, "a")]
		[InlineData(" _cat + 1", true, 5, "_cat")]
		[InlineData("cat_1 + 1", true, 5, "cat_1")]
		[InlineData("cat + 1", true, 3, "cat")]
		[InlineData("cat + mouse", true, 3, "cat")]
		[InlineData("+ cat + mouse", false, 0, "")]
		[InlineData("field.cat + 1", true, 9, "field.cat")]
		[InlineData("f0.cat0 + 1", true, 7, "f0.cat0")]

		//illegal names
		[InlineData("1_cat + 1", false, 0, "")]
		[InlineData("field.0_cat + 1", false, 0, "")]
		[InlineData("0field._cat + 1", false, 0, "")]
		[InlineData("field.cat.age + 1", true, 9, "field.cat")]
		[InlineData("f.c + 1", true, 3, "f.c")]
		public void TestVariableFactory(string text, bool parsed, int expected_text, string expected_value) {
			var factory = new VariableFactory();
			VerifyValueFactory(text, factory, parsed, expected_text, expected_value);
		}

		void VerifyValueFactory(string text, IExpressionFactory<IValueToken> factory, bool parsed, int expected_next, string expected_value) {
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
