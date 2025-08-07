using System;
using System.Threading.Tasks;

namespace Albatross.Expression.Context {
	public interface IContextValue {
		string Name { get; }
		object GetValue<T>(T input, Func<string, T, object> func);
		Task<object> GetValueAsync<T>(T input, Func<string, T, Task<object>> func);
	}
}