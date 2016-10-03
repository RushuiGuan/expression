using Albatross.Expression.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Albatross.Expression {
	public class ExpressionBuilder {
		public IParser Parser { get; private set; }
		public StringBuilder Content { get; private set; } = new StringBuilder();
		public ExpressionBuilder(IParser parser) {
			Parser = parser;
			Boundary = parser.StringLiteralToken().Boundary;
		}
		public char Boundary { get; private set; }

		public ExpressionBuilder Text(string value) {
			if (Content.Length > 0) {
				Content.Append("+");
			}
			Content.Append(Boundary);
			foreach (char c in value) {
				if (c == Boundary) {
					Content.Append(StringLiteralToken.EscapeChar);
					Content.Append(Boundary);
				}
				Content.Append(c);
			}
			Content.Append(Boundary);
			return this;
		}
		public ExpressionBuilder Expression(string value) {
			if (Content.Length > 0) {
				Content.Append("+");
			}
			Content.Append(value);
			return this;
		}
		public override string ToString() {
			return Content.ToString();
		}
	}
}
