using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Albatross.Expression.Test
{
	[TestFixture]
    public class ReflectionExecutionContextFactoryTest
    {
		public class Data {
			public int Apple { get; set; }
			public int Orange { get; set; }
			public int Banana { get; set; }
		}
		IExecutionContextFactory<Data> factory;
		public ReflectionExecutionContextFactoryTest() {
			factory = new ReflectionExecutionContextFactory<Data>(Factory.Instance.Create());
		}

		static IEnumerable<TestCaseData> GetTestCases() {
			return new TestCaseData[] {
				new TestCaseData("Apple + Orange + Banana", new Data { Apple = 1, Orange = 2, Banana = 3 }) { ExpectedResult = 6 },
				new TestCaseData("Apple * Orange - Banana", new Data { Apple = 100, Orange = 200, Banana = 300 }) { ExpectedResult = 19700 },
			};
		}


		[TestCaseSource(nameof(GetTestCases))]
		public object Run(string expression, Data data) {
			var context = factory.Create();
			return context.Eval(expression, data, null);
		}
    }
}
