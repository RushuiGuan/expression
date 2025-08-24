using System;
using System.Threading.Tasks;

namespace Albatross.Expression.Nodes {
	/// <summary>
	/// will only take true or false, case insensitive
	/// </summary>
	public class BooleanLiteral : ValueToken, IExpression {
		public BooleanLiteral(string value) : base(value) {
		}

		public object Eval(Func<string, object> _) {
			if (bool.TryParse(Value, out var value)) {
				return value;
			} else {
				throw new FormatException($"Cannot convert {Value} to boolean");
			}
		}

		public Task<object> EvalAsync(Func<string, Task<object>> context) => Task.FromResult(Eval(_ => new object()));
	}
}