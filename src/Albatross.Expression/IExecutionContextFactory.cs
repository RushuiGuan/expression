namespace Albatross.Expression {
	public interface IExecutionContextFactory<T> {
		bool CaseSensitive { get; set; }
		bool CacheExternalValue { get; set; }
		bool FailWhenMissingVariable { get; set; }

		IExecutionContext<T> Create();
		/// <summary>
		/// return false if the value is not found, otherwise return true and set the value to the out parameter.
		/// Note that the external value could be null
		/// </summary>
		/// <param name="name"></param>
		/// <param name="input"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		bool TryGetExternalValue(string name, T input, out object? value);
	}
}
