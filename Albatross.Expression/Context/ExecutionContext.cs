using Albatross.Expression.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace Albatross.Expression.Context {
	/// <summary>
	/// Abstract base class for execution contexts that provide variable resolution and evaluation capabilities.
	/// Manages variable lookups, circular reference detection, and both synchronous and asynchronous evaluation.
	/// </summary>
	/// <typeparam name="T">The type of the root context object.</typeparam>
	public abstract class ExecutionContext<T> : IExecutionContext<T> {
		/// <summary>
		/// Initializes a new instance of the ExecutionContext class.
		/// </summary>
		/// <param name="parser">The parser instance used for expression parsing and case-sensitivity settings.</param>
		protected ExecutionContext(IParser parser) {
			this.Parser = parser;
		}
		
		/// <summary>
		/// Gets the parser instance associated with this execution context.
		/// </summary>
		public IParser Parser { get; private set; }

		/// <summary>
		/// Creates a new set with appropriate case-sensitivity based on the parser configuration.
		/// </summary>
		/// <param name="items">The items to initialize the set with.</param>
		/// <returns>A HashSet with case-sensitive or case-insensitive comparison based on parser settings.</returns>
		ISet<string> NewSet(params IEnumerable<string> items) {
			return this.Parser.CaseSensitive
				? new HashSet<string>(items)
				: new HashSet<string>(items, StringComparer.InvariantCultureIgnoreCase);
		}

		#region data retrieval
		/// <summary>
		/// Gets the value of a variable by name from the execution context.
		/// Throws an exception if the variable is not found.
		/// </summary>
		/// <param name="name">The name of the variable to retrieve.</param>
		/// <param name="input">The root context object.</param>
		/// <returns>The value of the variable.</returns>
		/// <exception cref="MissingVariableException">Thrown when the variable is not found in the context.</exception>
		public object GetValue(string name, T input) {
			if (TryGetValue(name, input, out var value)) {
				return value;
			} else {
				throw new MissingVariableException(name);
			}
		}
		
		/// <summary>
		/// Abstract method that derived classes must implement to provide variable lookup logic.
		/// </summary>
		/// <param name="name">The name of the variable to look up.</param>
		/// <param name="value">When this method returns, contains the context value if found, or null if not found.</param>
		/// <returns>true if the variable was found; otherwise, false.</returns>
		protected abstract bool TryGetValueHandler(string name, [NotNullWhen(true)] out IContextValue<T>? value);

		/// <summary>
		/// Attempts to get the value of a variable by name from the execution context.
		/// Includes circular reference detection for expression-based context values.
		/// </summary>
		/// <param name="name">The name of the variable to retrieve.</param>
		/// <param name="input">The root context object.</param>
		/// <param name="data">When this method returns, contains the variable value if found, or null if not found.</param>
		/// <returns>true if the variable was found and evaluated successfully; otherwise, false.</returns>
		public bool TryGetValue(string name, T input, [NotNullWhen(true)] out object? data) {
			if (this.TryGetValueHandler(name, out var contextValue)) {
				if (contextValue is ExpressionContextValue<T> expressionContextValue) {
					CheckCircularReference(expressionContextValue, NewSet());
				}
				data = contextValue.GetValue(input, this.GetValue);
				return true;
			} else {
				data = null;
				return false;
			}
		}
		
		public async Task<object> GetValueAsync(string name, T input) {
			if (this.TryGetValueHandler(name, out var contextValue)) {
				if (contextValue is ExpressionContextValue<T> expressionContextValue) {
					CheckCircularReference(expressionContextValue, NewSet());
				}
				return await contextValue.GetValueAsync(input, this.GetValueAsync);
			} else {
				throw new MissingVariableException(name);
			}
		}
		#endregion

		#region dependency check
		void CheckCircularReference(ExpressionContextValue<T> contextValue, ISet<string> chain) {
			foreach (string dependee in contextValue.Dependees) {
				if (chain.Contains(dependee)) {
					throw new CircularReferenceException(dependee, contextValue.Name);
				}
				if (TryGetValueHandler(dependee, out var expression) && expression is ExpressionContextValue<T> expressionContextValue) {
					ISet<string> newChain = NewSet(chain);
					newChain.Add(dependee);
					CheckCircularReference(expressionContextValue, newChain);
				}
			}
		}
		#endregion
	}
}