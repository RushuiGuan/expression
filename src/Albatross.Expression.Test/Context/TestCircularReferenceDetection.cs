using Albatross.Expression.Context;
using Albatross.Expression.Exceptions;
using Albatross.Expression.Parsing;
using Xunit;

namespace Albatross.Expression.Test {
	public class TestCircularReferenceDetection {
		public static IEnumerable<object[]> TestCases() {
			return [
				["a", new Dictionary<string, string>{ { "a", "b+c" }, { "b", "a" }, { "c", "2" } }],
				["a", new Dictionary<string, string>{ { "a", "b" }, { "b", "c" }, { "c", "a" } }],
				["a", new Dictionary<string, string>{ { "a", "b" }, { "b", "c" }, { "c", "d" }, { "d", "b"} }],
				["a", new Dictionary<string, string>{ { "a", "b+1" }, { "b", "a+1" } }],
				["a", new Dictionary<string, string>{ { "a", "b+1" }, { "b", "c+1" }, { "c", "a+1"} }],
				["a", new Dictionary<string, string>{ { "a", "b+c+d+e" }, { "b", "c+1" }, { "c", "d+1"}, { "d", "e+1"}, { "e", "b+1"} }],
			];
		}

		[Theory]
		[MemberData(nameof(TestCases))]
		public void Run(string targetVariable, Dictionary<string, string> expressions) {
			var parser = new ParserBuilder().BuildDefault();
			var context = new Context.ExecutionContext<object>(parser);
			foreach (var item in expressions) {
				context.Set(new ExpressionContextValue<object>(item.Key, item.Value, parser));
			}
			Assert.Throws<CircularReferenceException>(() => context.GetValue(targetVariable, new object()));
		}
	}
}
