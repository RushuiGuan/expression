using Albatross.Expression.Exceptions;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

namespace Albatross.Expression.Test {
	[TestFixture]
	public class ExecutionContextTest {
		#region Test Case Generation
		static IEnumerable<ContextValue[]> CircularReferenceTestCase() {
			return new ContextValue[][] {
					new ContextValue[]{
						new ContextValue() { ContextType = ContextType.Expression, Name = "a", Value ="b+1"},
						new ContextValue() { ContextType = ContextType.Expression, Name = "b", Value = "a+1" },
					},
					new ContextValue[]{
						new ContextValue() { ContextType = ContextType.Expression, Name = "a", Value ="b+1"},
						new ContextValue() { ContextType = ContextType.Expression, Name = "b", Value = "c+1" },
						new ContextValue() { ContextType = ContextType.Expression, Name = "c", Value = "a+1" },
					},
					new ContextValue[]{
						new ContextValue() { ContextType = ContextType.Expression, Name = "a", Value ="b+c+d+e"},
						new ContextValue() { ContextType = ContextType.Expression, Name = "b", Value = "c+1" },
						new ContextValue() { ContextType = ContextType.Expression, Name = "c", Value = "d+1" },
						new ContextValue() { ContextType = ContextType.Expression, Name = "d", Value = "e+1" },
						new ContextValue() { ContextType = ContextType.Expression, Name = "e", Value = "b+1" },
					}
				};
		}
		static IEnumerable<TestCaseData> ExternalValueCircularReferenceTestCase() {
			List<TestCaseData> list = new List<TestCaseData>();
			foreach (var item in CircularReferenceTestCase()) {
				list.Add(new TestCaseData(true, item));
				list.Add(new TestCaseData(false, item));
			}
			return list;
		}
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

		[TestCaseSource(nameof(CircularReferenceTestCase))]
		public void CircularReferenceTesting(ContextValue[] values) {
			TestDelegate handle = new TestDelegate(() => {
				ExecutionContext context = new ExecutionContext(Factory.Instance.Create(), false);
				foreach (ContextValue value in values) {
					context.Set(value);
				}
				context.GetValue("a", null);
			});
			Assert.Throws<CircularReferenceException>(handle);
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

			ExecutionContext context = new ExecutionContext(Factory.Instance.Create(), false) { CacheExternalValue = caching, };
			context.TryGetExternalData = new TryGetValueDelegate((string name, object input, out object value) => {
				if (input is IDictionary<string, object>) {
					return ((IDictionary<string, object>)input).TryGetValue(name, out value);
				} else {
					value = null;
					return true;
				}
			});
			object result = context.GetValue("a", externals);
			return result;
		}

		[TestCaseSource(nameof(ExternalValueCircularReferenceTestCase))]
		public void ExternalValueWithCircularReference(bool caching, ContextValue[] values) {
			TestDelegate handle = new TestDelegate(() => {
				Dictionary<string, object> externals = new Dictionary<string, object>();
				foreach (ContextValue value in values) {
					if (value.ContextType == ContextType.Value) {
						externals.Add(value.Name, value.Value);
					} else {
						externals.Add(value.Name, value);
					}
				}

				ExecutionContext context = new ExecutionContext(Factory.Instance.Create(), false) { CacheExternalValue = caching, };
				context.TryGetExternalData = new TryGetValueDelegate((string name, object input, out object value) => {
					if (input is IDictionary<string, object>) {
						return ((IDictionary<string, object>)input).TryGetValue(name, out value);
					} else {
						value = null;
						return true;
					}
				});
				context.GetValue("a", externals);
			});
			Assert.Throws<CircularReferenceException>(handle);
		}
	}
}
