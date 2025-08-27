using System;
using System.Threading.Tasks;

namespace Albatross.Expression.Context {
	/// <summary>
	/// Context value that holds a static, pre-computed value.
	/// Does not depend on the input context and always returns the same value.
	/// </summary>
	/// <typeparam name="T">The type of the root context object.</typeparam>
	public class LocalContextValue<T> : IContextValue<T> {
		/// <summary>
		/// Initializes a new instance of the LocalContextValue class with a fixed value.
		/// </summary>
		/// <param name="name">The name of this context value.</param>
		/// <param name="value">The static value to return when evaluated.</param>
		public LocalContextValue(string name, object value) {
			Name = name;
			Value = value;
		}

		/// <summary>
		/// Gets the name of this context value.
		/// </summary>
		public string Name { get; }
		
		/// <summary>
		/// Gets the static value associated with this context value.
		/// </summary>
		public object Value { get; }

		/// <summary>
		/// Returns the static value, ignoring the input context and function parameters.
		/// </summary>
		/// <param name="input">The root context object (ignored).</param>
		/// <param name="func">Function to resolve variables (ignored).</param>
		/// <returns>The static value stored in this context value.</returns>
		public object GetValue(T input, Func<string, T, object> func) => this.Value;
		
		/// <summary>
		/// Asynchronously returns the static value, ignoring the input context and function parameters.
		/// </summary>
		/// <param name="input">The root context object (ignored).</param>
		/// <param name="func">Async function to resolve variables (ignored).</param>
		/// <returns>A completed task containing the static value.</returns>
		public Task<object> GetValueAsync(T input, Func<string, T, Task<object>> func) => Task.FromResult(this.Value);
	}
}