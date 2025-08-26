using System;
using System.Threading.Tasks;

namespace Albatross.Expression.Nodes {
	/// <summary>
	/// Represents a variable reference in an expression that gets resolved during evaluation.
	/// Variable names follow C# naming conventions and support dot notation for nested property access (e.g., "field.property").
	/// </summary>
	public class Variable : ValueToken, IExpression {
		/// <summary>
		/// Initializes a new instance of the <see cref="Variable"/> class.
		/// </summary>
		/// <param name="value">The variable name.</param>
		public Variable(string value) : base(value) {
		}

		public object Eval(Func<string, object> context) => context(Value);
		public Task<object> EvalAsync(Func<string, Task<object>> context) => context(this.Value);
	}
}