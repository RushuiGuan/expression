using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Albatross.Expression.Context {
	public class DefaultExecutionContext<T> : ExecutionContext<T> {
		public DefaultExecutionContext(IParser parser):base(parser) {
			Store = parser.CaseSensitive ? new Dictionary<string, IContextValue<T>>() : new Dictionary<string, IContextValue<T>>(StringComparer.InvariantCultureIgnoreCase);
		}

		protected override bool TryGetValueHandler(string name, [NotNullWhen(true)] out IContextValue<T>? value) {
			return Store.TryGetValue(name, out value);
		}
		
		public Dictionary<string, IContextValue<T>> Store { get; private set; }
		public void Clear() => Store.Clear();

		public void Set(IContextValue<T> value) {
			Store[value.Name] = value;
		}
	}
}