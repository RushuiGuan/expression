using Albatross.Expression.Parsing;
using Xunit;

namespace Albatross.Expression.Test.Valuation {
	public class TestOperations {
		[Theory]
		[InlineData("1 + 2", 3)]
		[InlineData("1 - 2", -1)]
		[InlineData("2 * 3", 6)]
		[InlineData("6 / 2", 3)]
		[InlineData("1 % 2", 1)]
		[InlineData("2 ^ 3", 8)]

		[InlineData("1 = 1", true)]
		[InlineData("1 = 2", false)]

		[InlineData("1 <> 1", false)]
		[InlineData("1 <> 2", true)]

		[InlineData("1 > 2", false)]
		[InlineData("2 > 1", true)]
		[InlineData("1 >= 1", true)]
		[InlineData("1 >= 2", false)]

		[InlineData("1 <= 1", true)]
		[InlineData("2 <= 1", false)]

		[InlineData("1 and 2", true)]
		[InlineData("0 and 2", false)]
		[InlineData("1 or 2", true)]
		[InlineData("0 or 2", true)]

		[InlineData("--1", 1)]
		[InlineData("-1", -1)]
		[InlineData("+-1", -1)]
		[InlineData("-+1", -1)]
		public void RunBasic(string text, object expected) {
			var parser = new ParserBuilder().BuildDefault();
			var expression = parser.Build(text);
			var result = expression.Eval(x => new object());
			Assert.Equivalent(expected, result);
		}


		[Theory]
		[InlineData("@(1,2,3)", 1, 2, 3)]
		public void TestArray(string text, params object[] expected) {
			var parser = new ParserBuilder().BuildDefault();
			var expression = parser.Build(text);
			var result = expression.Eval(x => new object());
			Assert.Equivalent(expected, result);
		}

		[Theory]
		[InlineData("arrayItem(@(100,200,300), 1)", 200)]
		[InlineData("avg(1, 2, 3)", 2)]
		[InlineData("dayOfWeek('2025-08-25T01:00')", 1)]
		[InlineData("floor(1.2)", 1)]
		[InlineData("Format(1.2, '#,#0.0000')", "1.2000")]
		[InlineData("JsonProperty('{\"name\": \"rushui\"}', '/name')", "rushui")]
		[InlineData("JsonProperty('{\"name\": null}', '/name', 'rushui')", "rushui")]
		[InlineData("if(1, 2, 3)", 2)]
		[InlineData("if(false, 2, 3)", 3)]
		[InlineData("left('abc', 2)", "ab")]
		[InlineData("len('abc')", 3)]
		[InlineData("lower('Abc')", "abc")]
		[InlineData("max(1,2,3)", 3)]
		[InlineData("min(1,2,3)", 1)]
		[InlineData("month('2025-12-01')", 12)]
		[InlineData("monthname('2025-12-01')", "December")]
		[InlineData("not(1)", false)]
		[InlineData("not(0)", true)]
		[InlineData("not(true)", false)]
		[InlineData("not(false)", true)]
		[InlineData("number('1')", 1)]
		[InlineData("number('1.5')", 1.5)]
		[InlineData("padLeft('abc', 5)", "  abc")]
		[InlineData("padLeft('abc', 5, '-')", "--abc")]
		[InlineData("padRight('abc', 5)", "abc  ")]
		[InlineData("padRight('abc', 5, '-')", "abc--")]
		[InlineData(@"regex(""$123%"", '(\\w+)')", "123")]
		[InlineData("right('abc', 2)", "bc")]
		[InlineData("round(1.2345, 2)", 1.23)]
		[InlineData("shortmonthname('2025-12-01')", "Dec")]
		[InlineData("text(1)", "1")]
		[InlineData(@"upper(""Abc"")", "ABC")]
		[InlineData("year('2025-12-01')", 2025)]
		public void TestPrefixOperations(string text, object expected) {
			var parser = new ParserBuilder().BuildDefault();
			var expression = parser.Build(text);
			var result = expression.Eval(x => new object());
			Assert.Equivalent(expected, result);
		}

		[Theory]
		[InlineData("createDate(2020, 1, 31)", "2020-01-31")]
		[InlineData("datetime('2020-01-31T01:00')", "2020-01-31T01:00")]
		[InlineData("nextweekday('2025-08-22')", "2025-08-25")]
		[InlineData("previousweekday('2025-08-25')", "2025-08-22")]
		public void TestDateTimePrefixOperations(string text, string expected) {
			var parser = new ParserBuilder().BuildDefault();
			var expression = parser.Build(text);
			var result = expression.Eval(x => new object());
			Assert.Equivalent(DateTime.Parse(expected), result);
		}
	}
}
