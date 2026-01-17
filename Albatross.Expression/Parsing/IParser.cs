using System.Collections.Generic;
using Albatross.Expression.Nodes;

namespace Albatross.Expression {
	/// <summary>
	/// Defines the core expression parsing functionality for tokenizing, converting, and building expression trees.
	/// </summary>
	public interface IParser {
		/// <summary>
		/// Indicates whether this parser performs case-sensitive matching for keywords and identifiers.
		/// </summary>
		bool CaseSensitive { get; }

		/// <summary>
		/// Parses an expression string from left to right and produces a queue of tokens in infix notation.
		/// </summary>
		/// <param name="expression">The expression string to tokenize.</param>
		/// <returns>A queue of tokens in the order they appear in the expression.</returns>
		Queue<IToken> Tokenize(string expression);

		/// <summary>
		/// Converts a token queue from infix notation to postfix (reverse Polish) notation using the shunting-yard algorithm.
		/// </summary>
		/// <param name="queue">The token queue in infix notation.</param>
		/// <returns>A stack of tokens in postfix notation for tree construction.</returns>
		Stack<IToken> BuildPostfixStack(Queue<IToken> queue);

		/// <summary>
		/// Constructs an abstract syntax tree from a postfix token stack.
		/// </summary>
		/// <param name="postfix">The token stack in postfix notation.</param>
		/// <returns>The root expression node of the constructed syntax tree.</returns>
		IExpression CreateTree(Stack<IToken> postfix);
	}
}
