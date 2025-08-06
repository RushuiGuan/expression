using Albatross.Expression.Nodes;
using System;

namespace Albatross.Expression.ExpressionFactory {
	public class ControlTokenFactory : IExpressionFactory<ControlToken> {
		public const string LeftParenthesisText = "(";
		public const string RightParenthesisText = ")";
		public const string CommaText = ",";
		public const string FuncParamStartText = "$"; // special symbol that mark the beginning of the function parameters

		public static readonly ControlTokenFactory LeftParenthesis = new(LeftParenthesisText);
		public static readonly ControlTokenFactory RightParenthesis = new(RightParenthesisText);
		public static readonly ControlTokenFactory Comma = new(CommaText);
		public static readonly ControlTokenFactory FuncParamStart = new(FuncParamStartText);


		public ControlTokenFactory(string tokenText) {
			TokenText = tokenText;
			Token = new ControlToken(tokenText);
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