using Albatross.Expression.Context;
using Albatross.Expression.Parsing;
using System.Threading.Tasks;
using Xunit;

namespace Albatross.Expression.Test.Context {
	public class TestNormalOperation {
		public static Task<string> GetCatFact() {
			return Task.FromResult("Cats are great!");
		}
		public static IEnumerable<object[]> TestCases() {
			return [
				["a", new Dictionary<string, string>{ { "a", "b+c" }, { "b", "1" }, { "c", "2" } }, 3],
				["a", new Dictionary<string, string> { { "a", "b+c" }, { "b", "1" }, { "c", "2+d" }, { "d", "3" } }, 6],
			];
		}

		[Theory]
		[MemberData(nameof(TestCases))]
		public void Run(string targetVariable, Dictionary<string, string> expressions, object expected) {
			var parser = new ParserBuilder().BuildDefault();
			var context = new DefaultExecutionContext<object>(parser);
			foreach (var item in expressions) {
				context.Set(new ExpressionContextValue<object>(item.Key, item.Value, parser));
			}
			var result = context.GetValue(targetVariable, new object());
			Assert.Equivalent(expected, result);
		}

		[Fact]
		public void RunWithExternalValues() {
			var parser = new ParserBuilder().BuildDefault();
			var context = new DefaultExecutionContext<Dictionary<string, object>>(parser);
			context.Set(new ExpressionContextValue<Dictionary<string, object>>("a", "b+c", parser));
			context.Set(new ExternalContextValue<Dictionary<string, object>>("b", dict=>dict["b"]));
			context.Set(new ExternalContextValue<Dictionary<string, object>>("c", dict => dict["c"]));
			var input = new Dictionary<string, object> { { "b", 1.0 }, { "c", 2 } };
			var result = context.GetValue("a", input);
			Assert.Equivalent(3, result);
		}


		[Fact]
		public async Task AsyncRunWithExternalValues() {
			var parser = new ParserBuilder().BuildDefault();
			var context = new DefaultExecutionContext<object>(parser);
			context.Set(new ExpressionContextValue<object>("fact", "upper(cat_fact)", parser));
			context.Set(new AsyncExternalContextValue<object>("cat_fact", async _ => await GetCatFact()));
			var result = await context.GetValueAsync("fact", new object());
			var expected = (await GetCatFact()).ToUpperInvariant();
			Assert.Equal(expected, result);
		}


		[Fact]
		public void RunWithLocalValues() {
			var parser = new ParserBuilder().BuildDefault();
			var context = new DefaultExecutionContext<object>(parser);
			context.Set(new ExpressionContextValue<object>("a", "b+c", parser));
			context.Set(new LocalContextValue<object>("b", 3));
			context.Set(new LocalContextValue<object>("c", 2));
			var result = context.GetValue("a", new object());
			Assert.Equivalent(5, result);
		}
	}
}
