using Albatross.Expression.ExpressionFactory;
using Albatross.Expression.Nodes;
using Xunit;

namespace Albatross.Expression.Test.Parsing {
	public class TestVariableParsing {
		[Theory]
		[InlineData("a", 1, "a")]
		[InlineData("a+b",  1, "a")]
		[InlineData("a.b",  3, "a.b")]
		[InlineData("a.b.c", 3, "a.b")]
		[InlineData("_a",  2, "_a")]
		[InlineData("_",  1, "_")]
		[InlineData("a1", 2, "a1")]
		// old test case
		[InlineData("a+b+c+d", 1, "a")]
		[InlineData(" _cat + 1", 5, "_cat")]
		[InlineData("cat_1 + 1", 5, "cat_1")]
		[InlineData("cat + 1", 3, "cat")]
		[InlineData("cat + mouse", 3, "cat")]
		[InlineData("field.cat + 1", 9, "field.cat")]
		[InlineData("f0.cat0 + 1", 7, "f0.cat0")]

		//illegal names
		[InlineData("field.cat.age + 1", 9, "field.cat")]
		[InlineData("f.c + 1", 3, "f.c")]
		public void VariableParsing_Success(string text, int expected_next, string expected_value) {
			new VariableFactory().VerifyValueFactory(text, true, expected_next, expected_value);
		}

		[Theory]
		[InlineData("")]
		// [InlineData("a.b.c")] this would match a.b
		[InlineData("1a")]
		// old test case
		[InlineData("+ cat + mouse")]

		//illegal names
		[InlineData("1_cat + 1")]
		// [InlineData("field.0_cat + 1")]  this would match field
		[InlineData("0field._cat + 1")]
		public void VariableParsing_Failure(string text) {
			new VariableFactory().VerifyValueFactory(text, false, 0, "");
		}
	}
}
