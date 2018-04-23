using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Albatross.Expression.Exceptions;

namespace Albatross.Expression.Tokens {
	public class SingleDoubleQuoteStringLiteralToken : StringLiteralToken {
		const char SingleQuote = '\'';
		const char DoubleQuote = '"';
		char boundary = DoubleQuote;
		public override char Boundary { get { return boundary; } }


		public override IToken Clone() {
			return new SingleDoubleQuoteStringLiteralToken();
		}

		public override bool Match(string expression, int start, out int next) {
			next = expression.Length;
			if (start < expression.Length) {
				while (start < expression.Length && char.IsWhiteSpace(expression[start])) {
					start++;
				}
				if (start < expression.Length && (expression[start] == SingleQuote || expression[start] == DoubleQuote)) {
					boundary = expression[start];

					StringBuilder sb = new StringBuilder();
					bool escaped = false, closed = false;
					char c;
					int i;
					for (i = start; i < expression.Length; i++) {
						c = expression[i];
						sb.Append(c);
						if (c == Boundary && i != start && !escaped) {
							closed = true;
							break;
						}
						escaped = !escaped && c == EscapeChar;
					}
					if (!closed) {
						throw new TokenParsingException("missing closing boundary");
					} else {
						next = i + 1;
						Name = sb.ToString();
						return true;
					}
				}
			}
			return false;
		}
	}
}