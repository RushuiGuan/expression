using System;
using System.Threading.Tasks;

namespace Albatross.Expression.Context {
	public class AsyncExternalContextValue<T> : IContextValue<T> {
		private readonly Func<T, Task<object>> func;

		public AsyncExternalContextValue(string name, Func<T, Task<object>> func) {
			this.func = func;
			this.Name = name;
		}

		public string Name { get; }
		public object GetValue(T input, Func<string, T, object> _) => throw new NotSupportedException();

		public async Task<object> GetValueAsync(T input, Func<string, T, Task<object>> _) {
			return await func(input);
		}
	}
}