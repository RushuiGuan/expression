using Albatross.Expression.Nodes;

namespace Albatross.Expression.Parsing {
	/// <summary>
	/// Factory interface for parsing tokens from expression text.
	/// </summary>
	/// <typeparam name="T">The type of token this factory produces.</typeparam>
	public interface IExpressionFactory<out T> where T : class, IToken {
		/// <summary>
		/// Attempts to parse a token from the given text starting at the specified position.
		/// </summary>
		/// <param name="text">The expression text to parse.</param>
		/// <param name="start">The starting position in the text to begin parsing.</param>
		/// <param name="next">When this method returns, contains the position after the parsed token, or the original start position if parsing failed.</param>
		/// <returns>The parsed token if successful; otherwise, null.</returns>
		T? Parse(string text, int start, out int next);
	}
}