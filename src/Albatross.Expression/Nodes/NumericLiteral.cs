using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace Albatross.Expression.Nodes {
	/// <summary>
	/// will take any numbers with decimals and without signs.
	/// </summary>
	public class NumericLiteral : IValueToken, IExpression {
		public NumericLiteral(string value) {
			Value = value;
		}
		public string Value { get; }
		public string Text() => Value;

		public object Eval(Func<string, object> context) {
			if (double.TryParse(Value, out var d)) {
				return d;
			} else {
				throw new FormatException($"Invalid numeric format: {Value}");
			}
		}
		public Task<object> EvalAsync(Func<string, Task<object>> context) => Task.FromResult(Eval(_ => new object()));
	}
}
