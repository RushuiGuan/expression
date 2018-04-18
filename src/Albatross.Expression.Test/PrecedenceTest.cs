using Albatross.Expression.Tokens;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albatross.Expression.Test {
	[TestFixture]
	public class PrecedenceTest {
		[TestCase("1+ 2/2", ExpectedResult = 2)]
		[TestCase("1+ 2*2", ExpectedResult = 5)]
		[TestCase("(1+ 2)*2", ExpectedResult = 6)]
		[TestCase("1* 6 * 3", ExpectedResult = 18)]
		[TestCase("1* 6 / 3", ExpectedResult = 2)]
		[TestCase("1* 2- 3", ExpectedResult = -1)]
		[TestCase("2* 2^3", ExpectedResult = 16)]
		[TestCase("max(6, 2* 2^3)", ExpectedResult = 16)]
		[TestCase("(1 - 1) and (2 + 6)", ExpectedResult = false)]
		[TestCase("1 or 1 and 0", ExpectedResult = true)]
		[TestCase("(1 or 1) and 0", ExpectedResult = false)]
		[TestCase("1--1", ExpectedResult = 2)]
		[TestCase("1--(1+1)", ExpectedResult = 3)]
		[TestCase("1-+1", ExpectedResult = 0)]
		[TestCase("10+avg(@(1,2,3,4))", ExpectedResult = 12.5)]
		[TestCase("(1 > 2) or (3 > 1)", ExpectedResult = true)]
		[TestCase("1 + 2> 2 - 1", ExpectedResult = true)]
		[TestCase("1 > 2 or 3 > 1", ExpectedResult = true)]
		public object PrecedenceTesting(string expression) {
			IParser parser = Factory.Instance.Create();
			IToken token = parser.Compile(expression);
			return token.EvalValue(null);
		}
	}
}
