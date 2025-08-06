using System;

namespace Albatross.Expression.Nodes {
	public record class ControlToken : INode {
		public ControlToken(string value) { Value = value; }
		public string Value { get; }
		public string Text() => Value;
	}

	public static class ControlTokenExtensions {
		public static bool IsLeftParenthesis(this INode token, bool value = true) 
			=> object.ReferenceEquals(token, ControlTokenFactory.LeftParenthesis.Token) == value;
		public static bool IsRightParenthesis(this INode token)
			=> object.ReferenceEquals(token, ControlTokenFactory.RightParenthesis.Token);
		public static bool IsComma(this INode token)
			=> object.ReferenceEquals(token, ControlTokenFactory.Comma.Token);
		public static bool IsFuncParamStart(this INode token, bool value = true)
			=> object.ReferenceEquals(token, ControlTokenFactory.FuncParamStart.Token) == value;
	}

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
			this.TokenText = tokenText;
			this.Token = new ControlToken(tokenText);
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