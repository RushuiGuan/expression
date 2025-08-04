using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Albatross.Expression.Tokens {
	public interface INode {
		string Name { get; }
		string Text(string format);
		object? Eval(Func<string, object> context);
	}
	public interface INodeFactory<T> where T : INode {
		bool TryMatch(string text, int start, out int next, [NotNullWhen(true)] out T? node);
	}
}
