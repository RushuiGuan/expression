using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace Albatross.Expression.Context {
	public interface IExecutionContext<T> {
		IParser Parser { get; }
		void Clear();
		object GetValue(string name, T input);
		bool TryGetValue(string name, T input, out object? data);
		Task<object> GetValueAsync(string name, T input);
		void Set(IContextValue<T> value);
	}
}
