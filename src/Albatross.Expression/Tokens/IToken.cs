using System;

namespace Albatross.Expression.Tokens {
	public interface IToken {
		string Name { get; }
		bool Match(string expression, int start, out int next);
		string EvalText(string format);
		object? EvalValue(Func<string, object?> context);
		IToken Clone();
	}
}
