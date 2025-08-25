using Albatross.Expression.ExpressionFactory;

namespace Albatross.Expression.Nodes {
	public class ControlToken : IToken {
		public string Token { get; }
		public string Text() => Token;
		public ControlToken(char token) {
			Token = token.ToString();
		}
	}

	public static class ControlTokenExtensions {
		public static bool IsLeftParenthesis(this IToken token, bool value = true)
			=> object.ReferenceEquals(token, ControlTokenFactory.LeftParenthesis.Token) == value;

		public static bool IsRightParenthesis(this IToken token)
			=> object.ReferenceEquals(token, ControlTokenFactory.RightParenthesis.Token);

		public static bool IsComma(this IToken token)
			=> object.ReferenceEquals(token, ControlTokenFactory.Comma.Token);

		public static bool IsFuncParamStart(this IToken token, bool value = true)
			=> object.ReferenceEquals(token, ControlTokenFactory.FuncParamStart.Token) == value;
	}
}