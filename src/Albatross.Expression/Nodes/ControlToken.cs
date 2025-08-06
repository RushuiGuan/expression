using Albatross.Expression.ExpressionFactory;

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
}