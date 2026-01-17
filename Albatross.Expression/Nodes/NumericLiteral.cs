using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace Albatross.Expression.Nodes {
	/// <summary>
	/// Represents a numeric literal that can be parsed as a double value.
	/// </summary>
	public class NumericLiteral : ValueToken, IExpression {
		/// <summary>
		/// Initializes a new instance of the <see cref="NumericLiteral"/> class.
		/// </summary>
		/// <param name="value">The string representation of the numeric value.</param>
		public NumericLiteral(string value) : base(value) {
		}

		/// <inheritdoc />
		public object Eval(Func<string, object> context) {
			if (double.TryParse(Value, out var d)) {
				return d;
			} else {
				throw new FormatException($"Invalid numeric format: {Value}");
			}
		}

		/// <inheritdoc />
		public Task<object> EvalAsync(Func<string, Task<object>> context) => Task.FromResult(Eval(_ => new object()));
	}
}