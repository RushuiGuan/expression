using System.Diagnostics.CodeAnalysis;

namespace Albatross.Expression.Nodes {
	public interface IExpressionFactory<out T> where T : class, INode {
		T? Parse(string text, int start, out int next);
	}
}