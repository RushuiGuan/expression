using System;
using System.Threading.Tasks;

namespace Albatross.Expression.Context {
	public class ExternalContextValue<T> : IContextValue<T> {
		private readonly Func<T, object> func;

		public ExternalContextValue(string name, Func<T, object> func) {
			this.func = func;
			this.Name = name;
		}

		public string Name { get; }
		public object GetValue(T input, Func<string, T, object> _) => func(input);

		public Task<object> GetValueAsync(T input, Func<string, T, Task<object>> _) => Task.FromResult(func(input));
	}
}