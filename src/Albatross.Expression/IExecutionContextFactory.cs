using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Albatross.Expression {
	public interface IExecutionContextFactory<T> {
		bool CaseSensitive { get; set; }
		bool CacheExternalValue { get; set; }
		bool FailWhenMissingVariable { get; set; }

		IExecutionContext<T> Create();
		bool TryGetExternalValue(string name, T input, out object? value);
	}
}
