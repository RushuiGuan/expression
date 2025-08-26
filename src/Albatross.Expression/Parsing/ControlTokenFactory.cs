using Albatross.Expression.Nodes;
using System;

namespace Albatross.Expression.Parsing {
	/// <summary>
	/// Factory for creating control tokens used in expression parsing (parentheses, commas, etc.).
	/// </summary>
	public class ControlTokenFactory : IExpressionFactory<ControlToken> {
		/// <summary>
		/// Character constant for left parenthesis.
		/// </summary>
		public const char LeftParenthesisChar = '(';
		
		/// <summary>
		/// Character constant for right parenthesis.
		/// </summary>
		public const char RightParenthesisChar = ')';
		
		/// <summary>
		/// Character constant for comma separator.
		/// </summary>
		public const char CommaChar = ',';
		
		/// <summary>
		/// Special character marking the beginning of function parameters in the parsing process.
		/// </summary>
		public const char FuncParamStartChar = '$';

		/// <summary>
		/// Singleton factory instance for left parenthesis tokens.
		/// </summary>
		public static readonly ControlTokenFactory LeftParenthesis = new(LeftParenthesisChar);
		
		/// <summary>
		/// Singleton factory instance for right parenthesis tokens.
		/// </summary>
		public static readonly ControlTokenFactory RightParenthesis = new(RightParenthesisChar);
		
		/// <summary>
		/// Singleton factory instance for comma tokens.
		/// </summary>
		public static readonly ControlTokenFactory Comma = new(CommaChar);
		
		/// <summary>
		/// Singleton factory instance for function parameter start tokens.
		/// </summary>
		public static readonly ControlTokenFactory FuncParamStart = new(FuncParamStartChar);

		/// <summary>
		/// Initializes a new instance of the <see cref="ControlTokenFactory"/> class.
		/// </summary>
		/// <param name="tokenChar">The character this factory will recognize and create tokens for.</param>
		public ControlTokenFactory(char tokenChar) {
			TokenText = tokenChar.ToString();
			Token = new ControlToken(tokenChar);
		}

		/// <summary>
		/// The string representation of the token character.
		/// </summary>
		public string TokenText { get; }
		
		/// <summary>
		/// The control token instance created by this factory.
		/// </summary>
		public ControlToken Token { get; }

		public ControlToken? Parse(string text, int start, out int next) {
			next = text.Length;
			if (start < text.Length) {
				while (start < text.Length && char.IsWhiteSpace(text[start])) {
					start++;
				}

				if (text.IndexOf(TokenText, start, StringComparison.Ordinal) == start) {
					next = start + TokenText.Length;
					return Token;
				}
			}
			return null;
		}
	}
}