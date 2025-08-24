using System;
using System.Text;
using Albatross.Expression.Exceptions;
using System.Threading.Tasks;

namespace Albatross.Expression.Nodes {
	/// <summary>
	/// will take any string literal enclosed by double quotes.  use back slash to escape.  
	/// Check the GetStringEscape function for escapable chars
	/// </summary>
	public class StringLiteral : ValueToken, IStringLiteral {
		public const char EscapeChar = '\\';
		public char Boundary { get; }
		
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