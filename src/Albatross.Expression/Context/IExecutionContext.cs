using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace Albatross.Expression.Context {
	public interface IExecutionContext<in T> {
		IParser Parser { get; }
		object GetValue(string name, T input);
		bool TryGetValue(string name, T input, out object? data);
		Task<object> GetValueAsync(string name, T input);
	}
}
