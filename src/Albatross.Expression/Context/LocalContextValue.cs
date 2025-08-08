using System;
using System.Threading.Tasks;

namespace Albatross.Expression.Context {
	public class LocalContextValue<T> : IContextValue<T> {
		public LocalContextValue(string name, object value) {
			Name = name;
			Value = value;
		}

		public string Name { get; }
		public object Value { get; }

		public object GetValue(T input, Func<string, T, object> func) => this.Value;
		public Task<object> GetValueAsync(T input, Func<string, T, Task<object>> func) => Task.FromResult(this.Value);
	}
}