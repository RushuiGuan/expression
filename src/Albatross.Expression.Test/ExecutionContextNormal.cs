using Albatross.Expression.Exceptions;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

namespace Albatross.Expression.Test {
	[TestFixture(TestOf = typeof(ExecutionContext<>))]
	public class ExecutionContextNormal {
		IExecutionContextFactory<IDictionary<string, object>> factory;
		public ExecutionContextNormal() {
			factory = new DictionaryExecutionContextFactory(Factory.Instance.Create());
		}

		static IEnumerable<TestCaseData> CaseInsensitiveNormalTest() {
			return new TestCaseData[] {
				new TestCaseData("a", null, new string[]{"a=b + c", "b=1", "c=2", }){ExpectedResult = 3},
				new TestCaseData("a", null, new string[]{ "a = b", "b = c", "c = 1"}){ExpectedResult = 1},
				new TestCaseData("a", null, new string[]{ "a=b+c+d", "b=1", "c=2", "d=3"}){ ExpectedResult = 6},
				new TestCaseData("a", null, new string[]{ "a=b+c+d", "b=c+d", "c=2", "d=3" }){ ExpectedResult = 10},

				new TestCaseData("a", new Dictionary<string, object>{ { "b", 2 }, { "c", 3} }, new string[]{"a=b + c" }){ExpectedResult = 5},
				new TestCaseData("a", new Dictionary<string, object>{ { "c", 3} }, new string[]{ "a = b", "b = c",}){ExpectedResult = 3},
				new TestCaseData("a",
					new Dictionary<string, object>{
						{ "c", 3},
						{ "b", 2},
						{ "a", new ContextValue { Name="a", ContextType = ContextType.Expression, Value = "c+b" } }
					},
					null
				){ ExpectedResult = 5 },
				new TestCaseData("a",
					new Dictionary<string, object>{
						{ "a", new ContextValue { Name="a", ContextType = ContextType.Expression, Value = "c+b" } }
					},
					new string[]{ "b = 3", "c = 2" }
				){ ExpectedResult = 5 },
			};
		}
		[TestCaseSource(nameof(CaseInsensitiveNormalTest))]
		public object NormalOperation(string target, IDictionary<string, object> input, IEnumerable<string> expressions) {
			factory.FailWhenMissingVariable = false;
			var context = factory.Create();
			if (expressions != null) {
				foreach (var item in expressions) {
					context.Set(item);
				}
			}
			return context.GetValue(target, input);
		}
	}
}
