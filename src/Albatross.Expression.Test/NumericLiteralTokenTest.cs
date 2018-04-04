using Albatross.Expression.Tokens;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Albatross.Expression.Test
{
	[TestFixture]
    public class NumericLiteralTokenTest {


		[TestCase(" 0  + 1 _a1 b c d", 0, ExpectedResult = " 0")]
		[TestCase(" 0.001 a_1 b c d", 0, ExpectedResult = " 0.001")]
		[TestCase("0.0.01 a b c d", 0, ExpectedResult ="0.0")]	//0.0.01 techinically is not a number, but the parser has the ability to error out when reading the next char .
		[TestCase("+ b c d", 0, ExpectedResult = null)]     //+ is a operator
		[TestCase("4 _xx c d", 0, ExpectedResult = "4")]
		public string Tokenize(string expression, int start) {
			int next;
			var construct = typeof(NumericLiteralToken).GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance).First();
			var token = (IOperandToken)construct.Invoke(new object[0]);
			if (token.Match(expression, start, out next)){
				return expression.Substring(start, next - start);
			} else {
				return null;
			}
		}
    }
}
