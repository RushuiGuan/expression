using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Albatross.Expression {
	public delegate bool TryGetValueDelegate<T>(string name, T input, [NotNullWhen(true)] out object? value);

	public interface IExecutionContext<T> :IEnumerable<ContextValue> {
		bool CaseSensitive { get; }
		bool CacheExternalValue { get; }
		bool FailWhenMissingVariable { get; }
		IParser Parser { get; }

		void Clear();
		object? Eval(string expression, T input, Type outputDataType);
		object? GetValue(string name, T input);
		bool TryGetValue(string name, T input, out object? data);
		void Set(ContextValue value);
		void Build();
	}
}
