namespace Albatross.Expression.Nodes {
	/// <summary>
	/// Represents a token that holds a value, typically a literal or variable reference.
	/// </summary>
	public interface IValueToken : IToken {
		/// <summary>
		/// The string value contained by this token.
		/// </summary>
		string Value { get; }
	}

	/// <summary>
	/// Basic implementation of a value token that stores a simple string value.
	/// </summary>
	public class ValueToken : IValueToken {
		/// <summary>
		/// The string value contained by this token.
		/// </summary>
		public string Value { get; }
		
		/// <summary>
		/// The token representation, which is the same as the Value for basic value tokens.
		/// </summary>
		public string Token => Value;
		
		/// <summary>
		/// Returns the text representation of this token.
		/// </summary>
		/// <returns>The text representation of the token.</returns>
		public string Text() => Value;
		
		/// <summary>
		/// Initializes a new instance of the <see cref="ValueToken"/> class with the specified value.
		/// </summary>
		/// <param name="value">The string value to store in this token.</param>
		public ValueToken(string value) {
			Value = value;
		}
	}
}