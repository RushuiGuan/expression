using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Albatross.Expression.Tokens {
	public interface IToken {
		string Name { get; }
		string EvalText(string format);
		object? EvalValue(Func<string, object> context);
	}
	public interface ITokenFactory<T> where T : IToken {
		bool TryMatch(string expression, int start, out int next, [MemberNotNullWhen(true)] out T? token);
	}
}
