using Albatross.Expression.Context;
using Albatross.Expression.Exceptions;
using Albatross.Expression.Parsing;
using Xunit;

namespace Albatross.Expression.Test.Context {
	public class TestMissingVariableError {
		public static IEnumerable<object[]> TestCases() {
			return [
				["a", new Dictionary<string, string>{ { "a", "b+c" }, { "b", "1" }}],
				["a", new Dictionary<string, string> { { "a", "b+c" }, { "b", "1" }, { "c", "1+d" } }],
			];
		}

		[Theory]
		[MemberData(nameof(TestCases))]
		public void Run(string targetVariable, Dictionary<string, string> expressions) {
			var parser = new ParserBuilder().BuildDefault();
			var context = new DefaultExecutionContext<object>(parser);
			foreach (var item in expressions) {
				context.Set(new ExpressionContextValue<object>(item.Key, item.Value, parser));
			}
			Assert.Throws<MissingVariableException>(() => context.GetValue(targetVariable, new object()));
		}
	}
}
