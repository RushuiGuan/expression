using Albatross.Expression.Exceptions;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

namespace Albatross.Expression.Test {
	[TestFixture(TestOf = typeof(ExecutionContext<>))]
	public class ExecutionContextCircularReference {
		IExecutionContextFactory<IDictionary<string, object>> factory;
		public ExecutionContextCircularReference() {
			factory = new DictionaryExecutionContextFactory(Factory.Instance.Create());
		}

		public static IEnumerable<TestCaseData> TestCases() {
			return new TestCaseData[] {
				new TestCaseData(null, new string[]{"a=b + c", "b=a", "c=2", }),
				new TestCaseData(null, new string[]{ "a = b", "b = c", "c = a"}),
				new TestCaseData(null, new string[]{ "a = b", "b = c", "c = d", "d = b"}),
				new TestCaseData(null, new string[]{ "a=b+1", "b=a+1"}),
				new TestCaseData(null, new string[]{ "a=b+1", "b=c+1", "c=a+1"}),
				new TestCaseData(null, new string[]{ "a=b+c+d+e", "b=c+1", "c=d+1", "d=e+1", "e=b+1"}),

				new TestCaseData(new Dictionary<string, object>{ { "c", new ContextValue("c", "b")} }, new string[]{ "a = b", "b = c",}),
				new TestCaseData(new Dictionary<string, object>{ { "c", new ContextValue("c", "b")}, { "b", new ContextValue("b", "c")}, { "a", new ContextValue("a", "b+c")} }, null),
			};
		}
		[TestCaseSource(nameof(TestCases))]
		public void CatchCircularReference(IDictionary<string, object> input, IEnumerable<string> expressions) {
			TestDelegate handle = new TestDelegate(() => {
				factory.FailWhenMissingVariable = false;
				var context = factory.Create();
				if (expressions != null) {
					foreach (var item in expressions) {
						context.Set(item);
					}
				}
				context.GetValue("a", input);
			});
			Assert.Catch<CircularReferenceException>(handle);
		}
	}
}
