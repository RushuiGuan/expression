using Albatross.Expression.Nodes;

namespace Albatross.Expression.Parsing {
	public interface IExpressionFactory<out T> where T : class, IToken {
		T? Parse(string text, int start, out int next);
	}
}