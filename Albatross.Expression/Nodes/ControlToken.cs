using Albatross.Expression.Parsing;

namespace Albatross.Expression.Nodes {
	/// <summary>
	/// Represents control tokens used for parsing expression structure (parentheses, commas, etc.).
	/// </summary>
	public class ControlToken : IToken {
		/// <summary>
		/// The token character as a string.
		/// </summary>
		public string Token { get; }
		
		/// <summary>
		/// Returns the text representation of this control token.
		/// </summary>
		/// <returns>The token character as a string.</returns>
		public string Text() => Token;
		
		/// <summary>
		/// Initializes a new instance of the <see cref="ControlToken"/> class.
		/// </summary>
		/// <param name="token">The control character for this token.</param>
		public ControlToken(char token) {
			Token = token.ToString();
		}
	}

	/// <summary>
	/// Provides extension methods for identifying different types of control tokens.
	/// </summary>
	public static class ControlTokenExtensions {
		/// <summary>
		/// Determines whether the token is a left parenthesis.
		/// </summary>
		/// <param name="token">The token to check.</param>
		/// <param name="value">The expected result (defaults to true).</param>
		/// <returns>True if the token is a left parenthesis and matches the expected value.</returns>
		public static bool IsLeftParenthesis(this IToken token, bool value = true)
			=> object.ReferenceEquals(token, ControlTokenFactory.LeftParenthesis.Token) == value;

		/// <summary>
		/// Determines whether the token is a right parenthesis.
		/// </summary>
		/// <param name="token">The token to check.</param>
		/// <returns>True if the token is a right parenthesis.</returns>
		public static bool IsRightParenthesis(this IToken token)
			=> object.ReferenceEquals(token, ControlTokenFactory.RightParenthesis.Token);

		/// <summary>
		/// Determines whether the token is a comma separator.
		/// </summary>
		/// <param name="token">The token to check.</param>
		/// <returns>True if the token is a comma.</returns>
		public static bool IsComma(this IToken token)
			=> object.ReferenceEquals(token, ControlTokenFactory.Comma.Token);

		/// <summary>
		/// Determines whether the token marks the start of function parameters.
		/// </summary>
		/// <param name="token">The token to check.</param>
		/// <param name="value">The expected result (defaults to true).</param>
		/// <returns>True if the token marks function parameter start and matches the expected value.</returns>
		public static bool IsFuncParamStart(this IToken token, bool value = true)
			=> object.ReferenceEquals(token, ControlTokenFactory.FuncParamStart.Token) == value;
	}
}