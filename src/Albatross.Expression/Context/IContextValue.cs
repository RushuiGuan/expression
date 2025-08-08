using System;
using System.Threading.Tasks;

namespace Albatross.Expression.Context {
	public interface IContextValue<T> {
		string Name { get; }
		object GetValue(T input, Func<string, T, object> func);
		Task<object> GetValueAsync(T input, Func<string, T, Task<object>> func);
	}
}