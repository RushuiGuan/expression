using Albatross.Expression.Tokens;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albatross.Expression.Test
{
	[TestFixture]
    public class VariableTokenTest {


		[TestCase("_a1 b c d", 0, ExpectedResult = "_a1")]
		[TestCase("a_1 b c d", 0, ExpectedResult = "a_1")]
		[TestCase("a b c d", 0, ExpectedResult ="a")]
		[TestCase("a b c d", 2, ExpectedResult = "b")]
		[TestCase("+ b c d", 0, ExpectedResult = null)]     //+ is a operator
		[TestCase("+ b c d", 1, ExpectedResult = " b")]     //starting from the space after the + sign
		[TestCase("4_xx c d", 0, ExpectedResult = null)]	//4_xx is not a valid variable name
		public string Tokenize(string expression, int start) {
			int next;
			if (new VariableToken().Match(expression, start, out next)){
				return expression.Substring(start, next - start);
			} else {
				return null;
			}
		}
    }
}
