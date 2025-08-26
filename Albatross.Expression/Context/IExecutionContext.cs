using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace Albatross.Expression.Context {
	/// <summary>
	/// Provides execution context for evaluating expressions with variable resolution.
	/// </summary>
	/// <typeparam name="T">The type of input object that provides context data.</typeparam>
	public interface IExecutionContext<in T> {
		/// <summary>
		/// The parser instance used for expression parsing.
		/// </summary>
		IParser Parser { get; }
		
		/// <summary>
		/// Retrieves the value of a named variable from the input context.
		/// </summary>
		/// <param name="name">The variable name to resolve.</param>
		/// <param name="input">The input object containing context data.</param>
		/// <returns>The resolved variable value.</returns>
		object GetValue(string name, T input);
		
		/// <summary>
		/// Attempts to retrieve the value of a named variable from the input context.
		/// </summary>
		/// <param name="name">The variable name to resolve.</param>
		/// <param name="input">The input object containing context data.</param>
		/// <param name="data">When this method returns, contains the resolved variable value if found; otherwise, null.</param>
		/// <returns>True if the variable was found and resolved; otherwise, false.</returns>
		bool TryGetValue(string name, T input, out object? data);
		
		/// <summary>
		/// Asynchronously retrieves the value of a named variable from the input context.
		/// </summary>
		/// <param name="name">The variable name to resolve.</param>
		/// <param name="input">The input object containing context data.</param>
		/// <returns>A task containing the resolved variable value.</returns>
		Task<object> GetValueAsync(string name, T input);
	}
}
