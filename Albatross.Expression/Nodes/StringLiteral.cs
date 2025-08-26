using System;
using System.Text;
using Albatross.Expression.Exceptions;
using System.Threading.Tasks;

namespace Albatross.Expression.Nodes {
	/// <summary>
	/// Represents a string literal enclosed by quotes with support for escape sequences.
	/// </summary>
	public class StringLiteral : ValueToken, IStringLiteral {
		/// <summary>
		/// The character used to escape special characters within the string literal.
		/// </summary>
		public const char EscapeChar = '\\';
		
		/// <summary>
		/// The boundary character (quote type) that delimits this string literal.
		/// </summary>
		public char Boundary { get; }
		
		/// <summary>
		/// Initializes a new instance of the <see cref="StringLiteral"/> class.
		/// </summary>
		/// <param name="boundary">The boundary character used to delimit the string.</param>
		/// <param name="value">The raw string value including boundary characters.</param>
		public StringLiteral(char boundary, string value):base(value) {
			this.Boundary = boundary;
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
		public Task<object> EvalAsync(Func<string, Task<object>> context) => Task.FromResult(Eval(_ => new object()));
	}
}