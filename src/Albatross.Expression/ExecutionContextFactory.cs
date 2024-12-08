using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Albatross.Expression {
	public class ExecutionContextFactory : IExecutionContextFactory<object> {
		public TryGetValueDelegate<object> DefaultTryGetValueDelegate { get; set; }
		public bool CaseSensitive { get;set; }
		public bool CacheExternalValue { get;set; }
		public bool FailWhenMissingVariable { get;set; }

		IParser parser;

		public ExecutionContextFactory(IParser parser) {
			this.parser = parser;
		}

		public IExecutionContext<object> Create() {
			return new ExecutionContext<object>(parser, CaseSensitive, CacheExternalValue, FailWhenMissingVariable, DefaultTryGetValueDelegate);
		}

		public bool TryGetExternalValue(string name, object input, out object? value) {
			value = null;
			return DefaultTryGetValueDelegate?.Invoke(name, input, out value) == true;
		}
	}
}
