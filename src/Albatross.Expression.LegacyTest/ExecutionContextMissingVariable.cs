using Albatross.Expression.Exceptions;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

namespace Albatross.Expression.Test {
	[TestFixture]
	public class ExecutionContextMissingVariable {
		IExecutionContextFactory<IDictionary<string, object>> factory;
		public ExecutionContextMissingVariable() {
			factory = new DictionaryExecutionContextFactory(Factory.Instance.Create());
		}

		static IEnumerable<TestCaseData> TestCases() {
			return new TestCaseData[] {
				new TestCaseData("a", new string[]{"a=b + c" }){ExpectedResult = null },
				new TestCaseData("a", new string[0]){ExpectedResult = null },
			};
		}
		[TestCaseSource(nameof(TestCases))]
		public object UseNullForMissingVariableTest(string target, IEnumerable<string> expressions) {
			factory.FailWhenMissingVariable = false;
			var context = factory.Create();
			foreach (var item in expressions) {
				context.Set(item);
			}
			return context.GetValue(target, null);
		}

		[TestCaseSource(nameof(TestCases))]
		public object FailForMissingVariableTest(string target, IEnumerable<string> expressions) {
			TestDelegate handle = new TestDelegate(() => {
				factory.FailWhenMissingVariable = true;
				var context = factory.Create();
				foreach (var item in expressions) {
					context.Set(item);
				}
				context.GetValue(target, null);
			});
			Assert.Catch<MissingVariableException>(handle);
			return null;
		}
	}
}
