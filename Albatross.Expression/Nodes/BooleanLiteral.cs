using System;
using System.Threading.Tasks;

namespace Albatross.Expression.Nodes {
	/// <summary>
	/// Represents a boolean literal with values 'true' or 'false' (case-insensitive).
	/// </summary>
	public class BooleanLiteral : ValueToken, IExpression {
		/// <summary>
		/// Initializes a new instance of the <see cref="BooleanLiteral"/> class.
		/// </summary>
		/// <param name="value">The string representation of the boolean value.</param>
		public BooleanLiteral(string value) : base(value) {
		}

		/// <inheritdoc />
		public object Eval(Func<string, object> _) {
			if (bool.TryParse(Value, out var value)) {
				return value;
			} else {
				throw new FormatException($"Cannot convert {Value} to boolean");
			}
		}

		/// <inheritdoc />
		public Task<object> EvalAsync(Func<string, Task<object>> context) => Task.FromResult(Eval(_ => new object()));
	}
}