using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Albatross.Expression.Context;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Parsing {
	/// <summary>
	/// Provides extension methods for parser operations and convenience methods.
	/// </summary>
	public static class Extensions {
		/// <summary>
		/// Builds an expression tree from the given expression string.
		/// </summary>
		/// <param name="parser">The parser instance to use.</param>
		/// <param name="expression">The expression string to parse.</param>
		/// <returns>The parsed expression tree.</returns>
		public static IExpression Build(this IParser parser, string expression) {
			var tokens = parser.Tokenize(expression);
			var stack = parser.BuildPostfixStack(tokens);
			return parser.CreateTree(stack);
		}

		/// <summary>
		/// Parses and evaluates an expression string using the provided execution context.
		/// </summary>
		/// <typeparam name="T">The type of input object for the execution context.</typeparam>
		/// <param name="parser">The parser instance to use.</param>
		/// <param name="expression">The expression string to parse and evaluate.</param>
		/// <param name="context">The execution context for variable resolution.</param>
		/// <param name="t">The input object containing context data.</param>
		/// <returns>The result of evaluating the expression.</returns>
		public static object Eval<T>(this IParser parser, string expression, IExecutionContext<T> context, T t) {
			var tree = parser.Build(expression);
			return tree.Eval(name => context.GetValue(name, t));
		}

		public static T? RegexParse<T>(this string text, Regex regex, Func<Match, string> capture, Func<string, T> func, int start, out int next) where T : class {
			next = text.Length;
			while (start < text.Length && char.IsWhiteSpace(text[start])) {
				start++;
			}
			if (start < text.Length) {
				Match match = regex.Match(text.Substring(start));
				if (match.Success) {
					var node = func(capture(match));
					next = start + match.Value.Length;
					return node;
				}
			}
			return null;
		}
	}
}