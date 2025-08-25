using System.Collections.Generic;
using Albatross.Expression.Nodes;

namespace Albatross.Expression {
	/// <summary>
	/// The interface contains functionalities to process an expression string.
	/// </summary>
	public interface IParser {
		bool CaseSensitive { get; }
		/// <summary>
		/// Parse a text expression from left to right and generate a token Queue
		/// </summary>
		/// <param name="expression"></param>
		/// <returns></returns>
		Queue<IToken> Tokenize(string expression);
		/// <summary>
		/// Convert a token queue to stack
		/// </summary>
		/// <param name="queue"></param>
		/// <returns></returns>
		Stack<IToken> BuildPostfixStack(Queue<IToken> queue);
		/// <summary>
		/// Using the token stack to build a token tree
		/// </summary>
		/// <param name="postfix"></param>
		/// <returns></returns>
		IExpression CreateTree(Stack<IToken> postfix);
	}
}
