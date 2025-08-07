using System;

namespace Albatross.Expression.Nodes {
	/// <summary>
	/// will only take true or false, case insensitive
	/// </summary>
	public class BooleanLiteral : IValueExpression {
		public BooleanLiteral(string value) {
			this.Value = value;
		}
		public string Value { get; }
		public string Text() => Value;

		public object Eval(Func<string, object> _) {
			if (bool.TryParse(Value, out var value)) {
				return value;
			} else {
				throw new FormatException($"Cannot convert {Value} to boolean");
			}
		}
	}
}