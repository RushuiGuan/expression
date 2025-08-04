using Albatross.Expression.Exceptions;
using Albatross.Expression.Nodes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albatross.Expression.Test
{
	public class Scenario {
		public Scenario(string expression, int index, string token, string result) {
			Expression = expression;
			StartingIndex = index;
			TokenizedPart = token;
			Result = result;
		}
		public string Expression { get; set; }
		public int StartingIndex { get; set; }
		public string Result { get; set; }
		public string TokenizedPart { get; set; }
	}

	[TestFixture]
    public class StringLiteralTest{
		static IEnumerable<Scenario> DoubleQuoteScenarios() {
			return new Scenario[] {
				//Basic scenario
				new Scenario("\"normal string\"", 0,"\"normal string\"", "normal string" ),
				new Scenario("  \"normal string\"", 2,"\"normal string\"", "normal string" ),
				// Leading white space
				new Scenario("  \"normal string\"", 0,"  \"normal string\"" , "normal string" ),
				// Trailing symbols
				new Scenario("\"normal string\" + 1", 0,"\"normal string\"" , "normal string" ),
				// Leading symbols
				new Scenario(" + \"normal string\" + 1", 0,null , null),
				new Scenario(" + \"normal string\" + 1", 3,"\"normal string\"" , "normal string" ),
				// Escape
				new Scenario("\"normal\\tstring\" + 1", 0,"\"normal\\tstring\"" , "normal\tstring" ),
				new Scenario("\"normal\\nstring\" + 1", 0,"\"normal\\nstring\"" , "normal\nstring" ),
				new Scenario("\"normal\\\"string\" + 1", 0,"\"normal\\\"string\"", "normal\"string" ),

				// Mixing single quotes
				new Scenario("\"normal 'big' string\"", 0,"\"normal 'big' string\"", "normal 'big' string" ),
				// Mixing both single and double quote
				new Scenario("\"normal\\\"'test'string\" + 1", 0,"\"normal\\\"'test'string\"" , "normal\"'test'string" ),
				// Empty string
				new Scenario("", 0,null , null),
				// No string found
				new Scenario("abc", 0,null , null),
				// invalid expression, but the first string should be tokenized
				new Scenario("\"abc\" + \"xxx", 0,"\"abc\"" , "abc"),
			};
		}

		static IEnumerable<Scenario> SingleQuoteScenarios() {
			return new Scenario[] {
				//Basic scenario
				new Scenario("  'normal string'", 2,"'normal string'", "normal string"),
				new Scenario("'normal string'", 0,"'normal string'","normal string"),
				// Leading white space
				new Scenario("  'normal string'", 0,"  'normal string'","normal string"),
				// Trailing symbols
				new Scenario("'normal string' + 1", 0,"'normal string'","normal string"),
				// Leading symbols
				new Scenario(" + 'normal string' + 1", 0,null,null),
				new Scenario(" + 'normal string' + 1", 3,"'normal string'","normal string"),
				// Escape
				new Scenario("'normal\\tstring' + 1", 0,"'normal\\tstring'","normal\tstring"),
				new Scenario("'normal\\nstring' + 1", 0,"'normal\\nstring'","normal\nstring"),

				// Mixing double quotes
				new Scenario("'normal \"big\" string'", 0,"'normal \"big\" string'" ,"normal \"big\" string"),
				// Mixing both single and double quote
				new Scenario("'normal\"\\'test\\'string' + 1", 0,"'normal\"\\'test\\'string'" ,"normal\"'test'string"),
				// Empty string
				new Scenario("", 0,null ,null),
				// No string found
				new Scenario("abc", 0,null ,null),
				// invalid expression, but the first string should be tokenized
				new Scenario("'abc' + 'xxx", 0,"'abc'" ,"abc"),
			};
		}

		static IEnumerable<TestCaseData> GetTokenizationTestCases() {
			List<TestCaseData> list = new List<TestCaseData>();
			foreach (var item in DoubleQuoteScenarios()) {
				list.Add(new TestCaseData(item.Expression, item.StartingIndex, typeof(DoubleQuoteString).AssemblyQualifiedName) { ExpectedResult = item.TokenizedPart });
				list.Add(new TestCaseData(item.Expression, item.StartingIndex, typeof(SingleDoubleQuoteStringLiteral).AssemblyQualifiedName) { ExpectedResult = item.TokenizedPart });
			}
			foreach (var item in SingleQuoteScenarios()) {
				list.Add(new TestCaseData(item.Expression, item.StartingIndex, typeof(SingleQuoteStringLiteral).AssemblyQualifiedName) { ExpectedResult = item.TokenizedPart });
				list.Add(new TestCaseData(item.Expression, item.StartingIndex, typeof(SingleDoubleQuoteStringLiteral).AssemblyQualifiedName) { ExpectedResult = item.TokenizedPart });
			}
			return list;
		}
		static IEnumerable<TestCaseData> GetEvalTestCases() {
			List<TestCaseData> list = new List<TestCaseData>();
			foreach (var item in DoubleQuoteScenarios()) {
				list.Add(new TestCaseData(item.Expression, item.StartingIndex, typeof(DoubleQuoteString).AssemblyQualifiedName) { ExpectedResult = item.Result });
				list.Add(new TestCaseData(item.Expression, item.StartingIndex, typeof(SingleDoubleQuoteStringLiteral).AssemblyQualifiedName) { ExpectedResult = item.Result });
			}
			foreach (var item in SingleQuoteScenarios()) {
				list.Add(new TestCaseData(item.Expression, item.StartingIndex, typeof(SingleQuoteStringLiteral).AssemblyQualifiedName) { ExpectedResult = item.Result });
				list.Add(new TestCaseData(item.Expression, item.StartingIndex, typeof(SingleDoubleQuoteStringLiteral).AssemblyQualifiedName) { ExpectedResult = item.Result });
			}
			return list;
		}


		[TestCaseSource(nameof(GetTokenizationTestCases))]
		public string StringLiteralTokenizationTest(string text, int start, string className) {
			INode token = (INode)Activator.CreateInstance(Type.GetType(className));
			int next;
			if (token.Match(text, start, out next)) {
				return text.Substring(start, next - start);
			} else {
				return null;
			}
		}

		[TestCaseSource(nameof(GetEvalTestCases))]
		public object StringLiteralEvalTest(string text, int start, string className) {
			INode token = (INode)Activator.CreateInstance(Type.GetType(className));
			int next;
			if (token.Match(text, start, out next)) {
				return token.Eval(null);
			} else {
				return null;
			}
		}

		[TestCase("this string is missing the opening quote\"", 0, ExpectedResult =false)]
		[TestCase("'this string is missing the opening quote\"", 0, ExpectedResult = false)]

		[TestCase("+ \"test\"", 0, ExpectedResult = false)]
		[TestCase("x \"test\"", 0, ExpectedResult = false)]
		[TestCase("( \"test\"", 0, ExpectedResult = false)]
		[TestCase("$ \"test\"", 0, ExpectedResult = false)]
		public bool FailToFindToken(string text, int start) {
			StringLiteral token = new DoubleQuoteString();
			int end;
			bool result = token.Match(text, start, out end);
			return result;
		}

		[TestCase("\"this string is missing the closing quote", 0)]
		[TestCase("\"this string is missing the closing quote'", 0)]
		public void CrashTest(string text, int start) {
			TestDelegate testDelegate = new TestDelegate(() => {
				StringLiteral token = new DoubleQuoteString();
				int next;
				token.Match(text, start, out next);
			});
			Assert.Catch<TokenParsingException>(testDelegate);
		}
    }
}
