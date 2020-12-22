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

		//legal names
		[TestCase("a+b+c+d", 0, ExpectedResult = "a")]
		[TestCase(" _cat + 1", 0, ExpectedResult = "_cat")]
		[TestCase("cat_1 + 1", 0, ExpectedResult = "cat_1")]
		[TestCase("cat + 1", 0, ExpectedResult ="cat")]
		[TestCase("cat + mouse", 5, ExpectedResult = "mouse")]
		[TestCase("+ cat + mouse", 0, ExpectedResult = null)]  
		[TestCase("+ cat + mouse", 1, ExpectedResult = "cat")]
		[TestCase("field.cat + 1", 0, ExpectedResult = "field.cat")]
		[TestCase("f0.cat0 + 1", 0, ExpectedResult = "f0.cat0")]

		//illegal names
		[TestCase("1_cat + 1", 0, ExpectedResult = null)]
		[TestCase("field.0_cat + 1", 0, ExpectedResult = "field")]
		[TestCase("0field._cat + 1", 0, ExpectedResult = null)]
		[TestCase("field.cat.age + 1", 0, ExpectedResult = "field.cat")]
		[TestCase("f.c + 1", 0, ExpectedResult = "f.c")]
		public string Tokenize(string expression, int start) {
			int next;
			VariableToken token = new VariableToken();
			if (token.Match(expression, start, out next)){
				return token.Name;
			} else {
				return null;
			}
		}
    }
}
