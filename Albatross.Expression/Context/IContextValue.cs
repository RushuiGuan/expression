using System;
using System.Threading.Tasks;

namespace Albatross.Expression.Context {
	/// <summary>
	/// Represents a context value that can be resolved during expression evaluation.
	/// </summary>
	/// <typeparam name="T">The type of input object used for value resolution.</typeparam>
	public interface IContextValue<T> {
		/// <summary>
		/// The name of this context value.
		/// </summary>
		string Name { get; }
		
		/// <summary>
		/// Retrieves the value using the provided input and context resolution function.
		/// </summary>
		/// <param name="input">The input object containing context data.</param>
		/// <param name="func">Function to resolve additional context values if needed.</param>
		/// <returns>The resolved value.</returns>
		object GetValue(T input, Func<string, T, object> func);
		
		/// <summary>
		/// Asynchronously retrieves the value using the provided input and context resolution function.
		/// </summary>
		/// <param name="input">The input object containing context data.</param>
		/// <param name="func">Function to asynchronously resolve additional context values if needed.</param>
		/// <returns>A task containing the resolved value.</returns>
		Task<object> GetValueAsync(T input, Func<string, T, Task<object>> func);
	}
}