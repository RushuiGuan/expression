using System;
using System.Threading.Tasks;

namespace Albatross.Expression.Context {
	/// <summary>
	/// Context value that delegates value retrieval to an asynchronous external function.
	/// Computes the value dynamically and asynchronously based on the input context using the provided async function.
	/// </summary>
	/// <typeparam name="T">The type of the root context object.</typeparam>
	public class AsyncExternalContextValue<T> : IContextValue<T> {
		private readonly Func<T, Task<object>> func;

		/// <summary>
		/// Initializes a new instance of the AsyncExternalContextValue class with an async value computation function.
		/// </summary>
		/// <param name="name">The name of this context value.</param>
		/// <param name="func">The async function that computes the value based on the input context.</param>
		public AsyncExternalContextValue(string name, Func<T, Task<object>> func) {
			this.func = func;
			this.Name = name;
		}

		/// <summary>
		/// Gets the name of this context value.
		/// </summary>
		public string Name { get; }
		
		/// <summary>
		/// Throws NotSupportedException as this context value only supports asynchronous evaluation.
		/// Use GetValueAsync instead for async-only context values.
		/// </summary>
		/// <param name="input">The root context object (ignored).</param>
		/// <param name="_">Function to resolve variables (ignored).</param>
		/// <returns>Never returns normally.</returns>
		/// <exception cref="NotSupportedException">Always thrown since this context value requires asynchronous evaluation.</exception>
		public object GetValue(T input, Func<string, T, object> _) => throw new NotSupportedException();

		/// <summary>
		/// Asynchronously computes and returns the value by invoking the external async function with the input context.
		/// Ignores the variable resolution function parameter since this value doesn't depend on other variables.
		/// </summary>
		/// <param name="input">The root context object passed to the computation function.</param>
		/// <param name="_">Async function to resolve variables (ignored).</param>
		/// <returns>A task containing the result of the async computation function.</returns>
		public async Task<object> GetValueAsync(T input, Func<string, T, Task<object>> _) {
			return await func(input);
		}
	}
}