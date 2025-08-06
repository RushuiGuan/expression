using Albatross.Expression.Nodes;
using System;

namespace Albatross.Expression.ExpressionFactory {
	public class ControlTokenFactory : IExpressionFactory<ControlToken> {
		public const char LeftParenthesisChar = '(';
		public const char RightParenthesisChar = ')';
		public const char CommaChar = ',';
		public const char FuncParamStartChar = '$'; // special symbol that mark the beginning of the function parameters

		public static readonly ControlTokenFactory LeftParenthesis = new(LeftParenthesisChar);
		public static readonly ControlTokenFactory RightParenthesis = new(RightParenthesisChar);
		public static readonly ControlTokenFactory Comma = new(CommaChar);
		public static readonly ControlTokenFactory FuncParamStart = new(FuncParamStartChar);


		public ControlTokenFactory(char tokenChar) {
			TokenText = tokenChar.ToString();
			Token = new ControlToken(tokenChar);
		}

		public string TokenText { get; }
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