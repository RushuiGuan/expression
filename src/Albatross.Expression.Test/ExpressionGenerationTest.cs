using Albatross.Expression.Nodes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albatross.Expression.Test {
	[TestFixture]
	public class ExpressionGenerationTest {

		[TestCase("1+1", ExpectedResult ="1 + 1")]
		[TestCase("1+2*3", ExpectedResult = "1 + 2 * 3")]
		[TestCase("1+(2*3)", ExpectedResult = "1 + 2 * 3")]
		[TestCase("(1+2)*3", ExpectedResult = "(1 + 2) * 3")]
		[TestCase("(1+2)*3 + today()", ExpectedResult = "(1 + 2) * 3 + Today()")]
		[TestCase("if(1>2, avg(1,2,3), max(2,3,4))", ExpectedResult = "If(1 > 2, avg(1, 2, 3), max(2, 3, 4))")]
		[TestCase("1--1", ExpectedResult = "1 - -1")]
		[TestCase("1+2+3", ExpectedResult = "1 + 2 + 3")]
		[TestCase("1+(2+3)", ExpectedResult = "1 + (2 + 3)")]
		[TestCase("(1+2)+3", ExpectedResult = "1 + 2 + 3")]
		public string GenerateExpression(string expression) {
			INode token = new Factory().Create().Compile(expression);
			return token.Text();
		}
	}
}
