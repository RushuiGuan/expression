using System;
using System.Diagnostics.CodeAnalysis;

namespace Albatross.Expression.Tokens {
	public interface INode {
		string Text();
		object? Eval(Func<string, object> context);
	}
	public interface INodeFactory<T> where T : INode {
		bool TryMatch(string text, int start, out int next, [NotNullWhen(true)] out T? node);
	}
}
