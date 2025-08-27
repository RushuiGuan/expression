using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Albatross.Expression.Context {
	/// <summary>
	/// Default implementation of execution context that maintains an in-memory store of variable values.
	/// Provides case-sensitive or case-insensitive variable lookups based on parser configuration.
	/// </summary>
	/// <typeparam name="T">The type of the root context object.</typeparam>
	public class DefaultExecutionContext<T> : ExecutionContext<T> {
		/// <summary>
		/// Initializes a new instance of the DefaultExecutionContext class.
		/// Creates an internal dictionary with case-sensitivity matching the parser's configuration.
		/// </summary>
		/// <param name="parser">The parser instance that determines case-sensitivity settings.</param>
		public DefaultExecutionContext(IParser parser):base(parser) {
			Store = parser.CaseSensitive ? new Dictionary<string, IContextValue<T>>() : new Dictionary<string, IContextValue<T>>(StringComparer.InvariantCultureIgnoreCase);
		}

		/// <summary>
		/// Attempts to retrieve a context value from the internal store by name.
		/// </summary>
		/// <param name="name">The name of the variable to look up.</param>
		/// <param name="value">When this method returns, contains the context value if found, or null if not found.</param>
		/// <returns>true if the variable was found in the store; otherwise, false.</returns>
		protected override bool TryGetValueHandler(string name, [NotNullWhen(true)] out IContextValue<T>? value) {
			return Store.TryGetValue(name, out value);
		}
		
		/// <summary>
		/// Gets the internal dictionary that stores variable names and their corresponding context values.
		/// </summary>
		public Dictionary<string, IContextValue<T>> Store { get; private set; }
		
		/// <summary>
		/// Removes all variables from the execution context store.
		/// </summary>
		public void Clear() => Store.Clear();

		/// <summary>
		/// Adds or updates a context value in the execution context store.
		/// </summary>
		/// <param name="value">The context value to add or update.</param>
		public void Set(IContextValue<T> value) {
			Store[value.Name] = value;
		}
	}
}