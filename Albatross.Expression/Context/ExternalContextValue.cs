using System;
using System.Threading.Tasks;

namespace Albatross.Expression.Context {
	/// <summary>
	/// Context value that delegates value retrieval to an external function.
	/// Computes the value dynamically based on the input context using the provided function.
	/// </summary>
	/// <typeparam name="T">The type of the root context object.</typeparam>
	public class ExternalContextValue<T> : IContextValue<T> {
		private readonly Func<T, object> func;

		/// <summary>
		/// Initializes a new instance of the ExternalContextValue class with a value computation function.
		/// </summary>
		/// <param name="name">The name of this context value.</param>
		/// <param name="func">The function that computes the value based on the input context.</param>
		public ExternalContextValue(string name, Func<T, object> func) {
			this.func = func;
			this.Name = name;
		}

		/// <summary>
		/// Gets the name of this context value.
		/// </summary>
		public string Name { get; }
		
		/// <summary>
		/// Computes and returns the value by invoking the external function with the input context.
		/// Ignores the variable resolution function parameter since this value doesn't depend on other variables.
		/// </summary>
		/// <param name="input">The root context object passed to the computation function.</param>
		/// <param name="_">Function to resolve variables (ignored).</param>
		/// <returns>The result of invoking the computation function with the input context.</returns>
		public object GetValue(T input, Func<string, T, object> _) => func(input);

		/// <summary>
		/// Asynchronously computes and returns the value by invoking the external function with the input context.
		/// Returns a completed task since the computation is synchronous.
		/// </summary>
		/// <param name="input">The root context object passed to the computation function.</param>
		/// <param name="_">Async function to resolve variables (ignored).</param>
		/// <returns>A completed task containing the result of the computation function.</returns>
		public Task<object> GetValueAsync(T input, Func<string, T, Task<object>> _) => Task.FromResult(func(input));
	}
}