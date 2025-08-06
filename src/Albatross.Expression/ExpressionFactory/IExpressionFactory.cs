using Albatross.Expression.Nodes;

namespace Albatross.Expression.ExpressionFactory {
	public interface IExpressionFactory<out T> where T : class, INode {
		T? Parse(string text, int start, out int next);
	}
}