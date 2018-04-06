using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albatross.Expression.Test {
	[TestFixture]
	public class ArrayTest {

		[TestCase("@(1,2,3,4)", ExpectedResult = 0)]
		public int LengthTest(string expression) {
			object value = new Factory().Create().Compile(expression).EvalValue(null);
			return 0;
		}
	}
}
