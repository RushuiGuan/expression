using Albatross.Expression.Exceptions;
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
    public class StringLiteralTokenTest{
		[TestCase("\"normal string\"", 0, ExpectedResult = "\"normal string\"", Description = "Basic scenario")]
		[TestCase("  \"normal string\"", 0, ExpectedResult = "  \"normal string\"", Description = "Leading white space")]
		[TestCase("  \"normal string\"", 2, ExpectedResult = "\"normal string\"")]
		[TestCase("\"normal string\" + 1", 0, ExpectedResult = "\"normal string\"", Description = "Trailing symbols")]
		[TestCase(" + \"normal string\" + 1", 0, ExpectedResult = null, Description = "Leading symbols")]
		[TestCase(" + \"normal string\" + 1", 3, ExpectedResult = "\"normal string\"", Description = "Leading symbols")]
		[TestCase("\"normal\\\tstring\" + 1", 0, ExpectedResult = "\"normal\\\tstring\"", Description = "Escape")]
		[TestCase("\"normal\\nstring\" + 1", 0, ExpectedResult = "\"normal\\nstring\"", Description = "Escape")]
		[TestCase("", 0, ExpectedResult = null, Description = "Empty string")]
		[TestCase("abc", 0, ExpectedResult = null, Description = "No string found")]
		[TestCase("\"abc\" + \"xxx", 0, ExpectedResult = "\"abc\"", Description = "invalid expression, but the first string should be tokenized")]
		public string DoubleQuoteStringLiteralTokenTest(string text, int start) {
			StringLiteralToken token = new DoubleQuoteStringLiteralToken();
			int next;
			if (token.Match(text, start, out next)) {
				return text.Substring(start, next - start);
			} else {
				return null;
			}
		}

		[TestCase("'normal string'", 0, ExpectedResult = "'normal string'", Description = "Basic scenario")]
		[TestCase("  'normal string'", 0, ExpectedResult = "  'normal string'", Description = "Leading white space")]
		[TestCase("  'normal string'", 2, ExpectedResult = "'normal string'")]
		[TestCase("'normal string' + 1", 0, ExpectedResult = "'normal string'", Description = "Trailing symbols")]
		[TestCase(" + 'normal string' + 1", 0, ExpectedResult = null, Description = "Leading symbols")]
		[TestCase(" + 'normal string' + 1", 3, ExpectedResult = "'normal string'", Description = "Leading symbols")]
		[TestCase("'normal\\\tstring' + 1", 0, ExpectedResult = "'normal\\\tstring'", Description = "Escape")]
		[TestCase("'normal\\nstring' + 1", 0, ExpectedResult = "'normal\\nstring'", Description = "Escape")]
		public string SingleQuoteStringLiteralTokenTest(string text, int start) {
			StringLiteralToken token = new SingleQuoteStringLiteralToken();
			int next;
			if (token.Match(text, start, out next)) {
				return text.Substring(start, next - start);
			} else {
				return null;
			}
		}

		[TestCase("\"normal string\"", 0, ExpectedResult = "normal string", Description = "Basic scenario")]
		[TestCase("  \"normal string\"", 0, ExpectedResult = "normal string", Description = "Leading white space")]
		[TestCase("  \"normal string\"", 2, ExpectedResult = "normal string")]
		[TestCase("\"normal string\" + 1", 0, ExpectedResult = "normal string", Description = "Trailing symbols")]
		[TestCase(" + \"normal string\" + 1", 0, ExpectedResult = null, Description = "Leading symbols")]
		[TestCase(" + \"normal string\" + 1", 3, ExpectedResult = "normal string", Description = "Leading symbols")]
		[TestCase("\"normal\\nstring\" + 1", 0, ExpectedResult = "normal\nstring", Description = "Escape")]
		public object DoubleQuoteStringLiteralEval(string text, int start) {
			StringLiteralToken token = new DoubleQuoteStringLiteralToken();
			int next;
			if (token.Match(text, start, out next)) {
				return token.EvalValue(null);
			} else {
				return null;
			}
		}

		[TestCase("\'normal string\'", 0, ExpectedResult = "normal string", Description = "Basic scenario")]
		[TestCase("  \'normal string\'", 0, ExpectedResult = "normal string", Description = "Leading white space")]
		[TestCase("  \'normal string\'", 2, ExpectedResult = "normal string")]
		[TestCase("\'normal string\' + 1", 0, ExpectedResult = "normal string", Description = "Trailing symbols")]
		[TestCase(" + \'normal string\' + 1", 0, ExpectedResult = null, Description = "Leading symbols")]
		[TestCase(" + 'normal string' + 1", 3, ExpectedResult = "normal string", Description = "Leading symbols")]
		[TestCase("\'normal\\nstring\' + 1", 0, ExpectedResult = "normal\nstring", Description = "Escape")]
		public object SingleQuoteStringLiteralEval(string text, int start) {
			StringLiteralToken token = new SingleQuoteStringLiteralToken();
			int next;
			if (token.Match(text, start, out next)) {
				return token.EvalValue(null);
			} else {
				return null;
			}
		}

		[TestCase("this string is missing the opening quote\"", 0, ExpectedResult =false)]
		[TestCase("+ \"test\"", 0, ExpectedResult = false)]
		[TestCase("x \"test\"", 0, ExpectedResult = false)]
		[TestCase("( \"test\"", 0, ExpectedResult = false)]
		[TestCase("$ \"test\"", 0, ExpectedResult = false)]
		public bool FailToFindToken(string text, int start) {
			StringLiteralToken token = new DoubleQuoteStringLiteralToken();
			int end;
			bool result = token.Match(text, start, out end);
			return result;
		}

		[TestCase("\"this string is missing the closing quote", 0)]
		public void CrashTest(string text, int start) {
			TestDelegate testDelegate = new TestDelegate(() => {
				StringLiteralToken token = new DoubleQuoteStringLiteralToken();
				int next;
				token.Match(text, start, out next);
			});
			Assert.Catch<TokenParsingException>(testDelegate);
		}
    }
}
