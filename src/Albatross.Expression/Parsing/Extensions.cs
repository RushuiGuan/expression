using Albatross.Expression.Context;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Parsing {
	public static class Extensions {
		public static IExpression Build(this IParser parser, string expression) {
			var tokens = parser.Tokenize(expression);
			var stack = parser.BuildPostfixStack(tokens);
			return parser.CreateTree(stack);
		}

		public static object Eval<T>(this IParser parser, string expression, IExecutionContext<T> context, T t) {
			var tree = parser.Build(expression);
			return tree.Eval(name => context.GetValue(name, t));
		}
	}
}
