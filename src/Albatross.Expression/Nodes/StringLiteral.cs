using System;
using System.Text;
using Albatross.Expression.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace Albatross.Expression.Nodes {
	/// <summary>
	/// will take any string literal enclosed by double quotes.  use back slash to escape.  
	/// Check the GetStringEscape function for escapable chars
	/// </summary>
	public class StringLiteral : IStringLiteral {
		public const char EscapeChar = '\\';
		public char Boundary { get; }
		
		public StringLiteral(char boundary, string value) {
			this.Boundary = boundary;
			this.Value = value;
		}

		public string Value { get; protected set; }
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
		public override string ToString() { return Value; }
		public string Text() => Value;
		public object Eval(Func<string, object> context) {
			var sb = new StringBuilder();
			bool escaped = false;
			for (int i = 1; i < Value.Length - 1; i++) {
				if (escaped) {
					sb.Append(GetEscapedChar(Value[i]));
					escaped = false;
				} else {
					escaped = Value[i] == EscapeChar;
					if (!escaped) { sb.Append(Value[i]); }
				}
			}
			return sb.ToString();
		}
	}
	public class StringLiteralFactory : IExpressionFactory<StringLiteral> {
		private readonly char boundary;
		public StringLiteralFactory(char boundary) {
			this.boundary = boundary;
		}
		public StringLiteral? Parse(string text, int start, out int next) {
			next = text.Length;
			if (start < text.Length) {
				while (start < text.Length && char.IsWhiteSpace(text[start])) {
					start++;
				}
				if (start < text.Length && text[start] == boundary) {
					var sb = new StringBuilder();
					bool escaped = false, closed = false;
					char c;
					int i;
					for (i = start; i < text.Length; i++) {
						c = text[i];
						sb.Append(c);
						if (c == boundary && i != start && !escaped) {
							closed = true;
							break;
						}
						escaped = !escaped && c == StringLiteral.EscapeChar;
					}
					if (!closed) {
						throw new TokenParsingException("missing closing boundary");
					} else {
						next = i + 1;
						return new StringLiteral(boundary, sb.ToString());
					}
				}
			}
			return null;
		}
	}
}