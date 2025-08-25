using Albatross.Expression.Nodes;

namespace Albatross.Expression.Parsing {
	public static class Extensions {
		public static IExpression Build(this IParser parser, string expression) {
			var tokens = parser.Tokenize(expression);
			var stack = parser.BuildPostfixStack(tokens);
			return parser.CreateTree(stack);
		}
	}
}
