using Albatross.Expression.Exceptions;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

namespace Albatross.Expression.Test {
	[TestFixture]
	public class ExecutionContextTest {
		#region Test Case Generation
		static TestCaseData[] ExternalValueTestCase() {
			return new TestCaseData[] {
				new TestCaseData(
					true,
					new ContextValue[]{
						new ContextValue() { Name = "a", Value = "b + c + d", ContextType = ContextType.Expression },
							new ContextValue() { Name = "b", Value = 1},
							new ContextValue() { Name = "c", Value = 2},
							new ContextValue() { Name = "d", Value = 3},
					}){ ExpectedResult = 6},
					new TestCaseData(
						true,
						new ContextValue[]{
							new ContextValue() { Name = "a", Value = "b + c + d", ContextType = ContextType.Expression },
							new ContextValue() { Name = "b", Value = "c + d", ContextType = ContextType.Expression,},
							new ContextValue() { Name = "c", Value = 2},
							new ContextValue() { Name = "d", Value = 3},
					}){ ExpectedResult = 10},
					new TestCaseData(
						false,
						new ContextValue[]{
							new ContextValue() { Name = "a", Value = "b + c + d", ContextType = ContextType.Expression },
							new ContextValue() { Name = "b", Value = 1},
							new ContextValue() { Name = "c", Value = 2},
							new ContextValue() { Name = "d", Value = 3},
					}){ ExpectedResult = 6},
					new TestCaseData(
						false,
						new ContextValue[]{
							new ContextValue() { Name = "a", Value = "b + c + d", ContextType = ContextType.Expression },
							new ContextValue() { Name = "b", Value = "c + d", ContextType = ContextType.Expression,},
							new ContextValue() { Name = "c", Value = 2},
							new ContextValue() { Name = "d", Value = 3},
					}){ ExpectedResult = 10},
			};
		}
		#endregion

		[TestCaseSource(nameof(ExternalValueTestCase))]
		public object ExternalValueTesting(bool caching, ContextValue[] values) {
			Dictionary<string, object> externals = new Dictionary<string, object>();
			foreach (ContextValue value in values) {
				if (value.ContextType == ContextType.Value) {
					externals.Add(value.Name, value.Value);
				} else {
					externals.Add(value.Name, value);
				}
			}
			DictionaryExecutionContextFactory factory = new DictionaryExecutionContextFactory(Factory.Instance.Create());
			var context = factory.Create();
			object result = context.GetValue("a", externals);
			return result;
		}
	}
}
