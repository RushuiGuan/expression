using System;
using System.Diagnostics.CodeAnalysis;

namespace Albatross.Expression.Nodes {
	public interface INode {
		string Text();
	}
	public interface IExpressionFactory<T> where T : INode {
		bool TryParse(string text, int start, out int next, [NotNullWhen(true)] out T? node);
	}
}