using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Albatross.Expression.Exceptions;

namespace Albatross.Expression.Tokens {
	/// <summary>
	/// will take any string literal enclosed by double quotes.  use back slash to escape.  
	/// Check the GetStringEscape function for escapable chars
	/// </summary>
	public abstract class StringLiteralToken : IOperandToken, IStringLiteralToken {
		public const char EscapeChar = '\\';
		public abstract char Boundary { get; }
		public abstract IToken Clone();

		public string Name { get; private set; }
		public string Group { get { return "Literal"; } }
		public bool Match(string expression, int start, out int next) {
			next = expression.Length;
			if (start < expression.Length) {
				while (start < expression.Length && char.IsWhiteSpace(expression[start])) {
					start++;
				}
				if (start < expression.Length && expression[start] == Boundary) {
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
		char GetEscapedChar(char c) {
			if (c == 'n') {
				return '\n';
			} else if (c == 't') {
				return '\t';
			} else if (c == Boundary || c == '\\') {
				return c;
			} else {
				throw new TokenParsingException("Invalid string escape \\" + c);
			}
		}
		public override string ToString() { return Name; }
		public string EvalText(string format) {
			return Name;
		}
		public object EvalValue(Func<string, object> context) {
			StringBuilder sb = new StringBuilder();
			bool escaped = false;
			for (int i = 1; i < Name.Length - 1; i++) {
				if (escaped) {
					sb.Append(GetEscapedChar(Name[i]));
					escaped = false;
				} else {
					escaped = Name[i] == EscapeChar;
					if (!escaped) { sb.Append(Name[i]); }
				}
			}
			return sb.ToString();
		}
		public bool IsVariable { get { return false; } }
	}
}