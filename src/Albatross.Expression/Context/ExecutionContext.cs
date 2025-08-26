using Albatross.Expression.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace Albatross.Expression.Context {
	public abstract class ExecutionContext<T> : IExecutionContext<T> {
		protected ExecutionContext(IParser parser) {
			this.Parser = parser;
		}
		
		public IParser Parser { get; private set; }

		ISet<string> NewSet(params string[] items) {
			return this.Parser.CaseSensitive
				? new HashSet<string>(items)
				: new HashSet<string>(items, StringComparer.InvariantCultureIgnoreCase);
		}
		
		ISet<string> NewSet(ISet<string> source) {
			return this.Parser.CaseSensitive
				? new HashSet<string>(source)
				: new HashSet<string>(source, StringComparer.InvariantCultureIgnoreCase);
		}

		#region data retrieval
		public object GetValue(string name, T input) {
			if (TryGetValue(name, input, out var value)) {
				return value;
			} else {
				throw new MissingVariableException(name);
			}
		}
		
		protected abstract bool TryGetValueHandler(string name, [NotNullWhen(true)] out IContextValue<T>? value);

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