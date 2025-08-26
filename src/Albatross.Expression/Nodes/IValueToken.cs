namespace Albatross.Expression.Nodes {
	public interface IValueToken : IToken {
		string Value { get; }
	}

	public class ValueToken : IValueToken {
		public string Value { get; }
		public string Token => Value;
		public string Text() => Value;
		public ValueToken(string value) {
			Value = value;
		}
	}
}