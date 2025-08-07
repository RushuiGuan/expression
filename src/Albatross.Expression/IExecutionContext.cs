using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Albatross.Expression {
	public delegate bool TryGetValueDelegate<in T>(string name, T input, [NotNullWhen(true)] out object? value);

	public interface IExecutionContext<in T> {
		IParser Parser { get; }
		void Clear();
		object GetValue(string name, T input);
		bool TryGetValue(string name, T input, out object? data);
		void Set(ContextValue value);
		void Build();
	}
}
