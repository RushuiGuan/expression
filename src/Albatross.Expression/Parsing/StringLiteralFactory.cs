using System.Text;
using Albatross.Expression.Exceptions;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Parsing {
	/// <summary>
	/// Factory for parsing string literal tokens with support for different quote characters.
	/// </summary>
	public class StringLiteralFactory : IExpressionFactory<StringLiteral> {
		/// <summary>
		/// Singleton factory instance for double-quoted string literals.
		/// </summary>
		public readonly static StringLiteralFactory DoubleQuote = new StringLiteralFactory('"');
		
		/// <summary>
		/// Singleton factory instance for single-quoted string literals.
		/// </summary>
		public readonly static StringLiteralFactory SingleQuote = new StringLiteralFactory('\'');

		private readonly char boundary;
		
		/// <summary>
		/// Initializes a new instance of the <see cref="StringLiteralFactory"/> class.
		/// </summary>
		/// <param name="boundary">The quote character used to delimit string literals.</param>
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