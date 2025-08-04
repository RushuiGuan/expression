using System.Collections.Generic;

namespace Albatross.Expression {
	public class DictionaryExecutionContextFactory : IExecutionContextFactory<IDictionary<string, object>> {
		IParser parser;

		public bool CaseSensitive { get; set; }
		public bool CacheExternalValue { get; set; }
		public bool FailWhenMissingVariable { get; set; }


		public DictionaryExecutionContextFactory(IParser parser) {
			this.parser = parser;
			CaseSensitive = true;
			CacheExternalValue = false;
			FailWhenMissingVariable = true;
		}

		public IExecutionContext<IDictionary<string, object>> Create() {
			return new ExecutionContext<IDictionary<string, object>>(parser, CaseSensitive, CacheExternalValue, FailWhenMissingVariable, TryGetExternalValue);
		}

		public bool TryGetExternalValue(string name, IDictionary<string, object> input, out object? value) {
			if (input != null) {
				return input.TryGetValue(name, out value);
			} else { 
				value = null;
				return false;
			}
		}
	}
}
