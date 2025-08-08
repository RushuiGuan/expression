using Albatross.Expression.Exceptions;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

namespace Albatross.Expression.Test {
	[TestFixture(TestOf =(typeof(Extensions)))]
	public class ExtensionMethodTest {
		IExecutionContextFactory<IDictionary<string, object>> factory;
		public ExtensionMethodTest() {
			factory = new DictionaryExecutionContextFactory(Factory.Instance.Create());
		}




		[TestCase(" a = 1 + 1", ExpectedResult = "a")]
		[TestCase("a = 1 + 1", ExpectedResult ="a")]
		public string AssignmentExpressionNameTest(string expression) {
			var context = factory.Create();
			var value = context.Set(expression);
			return value.Name;
		}

		[TestCase("a =1 + 1", ExpectedResult = "1 + 1")]
		[TestCase("a = 1 + 1", ExpectedResult =" 1 + 1")]
		[TestCase("a = ", ExpectedResult = " ")]
		[TestCase("a =", ExpectedResult = "")]
		public string AssignmentExpressionValueTest(string expression) {
			var context = factory.Create();
			var value = context.Set(expression);
			return System.Convert.ToString(value.Value);
		}

		[TestCase("")]
		[TestCase(" ")]
		[TestCase("=")]
		[TestCase(" = ")]
		[TestCase("A + 1= ")]
		[TestCase("%% = ")]
		public void AssignmentExpressionFailureTest(string expression) {
			TestDelegate handle = new TestDelegate(() => {
				var context = factory.Create();
				var value = context.Set(expression);
			});
			Assert.Catch<TokenParsingException>(handle);
		}
	}
}
