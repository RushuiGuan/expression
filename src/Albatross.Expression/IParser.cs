using Albatross.Expression.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Nodes;

namespace Albatross.Expression {
	/// <summary>
	/// The interface contains functionalities to process an expression string.
	/// </summary>
	public interface IParser {
		/// <summary>
		/// Parse a text expression from left to right and generate a token Queue
		/// </summary>
		/// <param name="expression"></param>
		/// <returns></returns>
		Queue<INode> Tokenize(string expression);
		/// <summary>
		/// Convert a token queue to stack
		/// </summary>
		/// <param name="queue"></param>
		/// <returns></returns>
		Stack<INode> BuildStack(Queue<INode> queue);
		/// <summary>
		/// Using the token stack to build a token tree
		/// </summary>
		/// <param name="postfix"></param>
		/// <returns></returns>
		INode CreateTree(Stack<INode> postfix);
		/// <summary>
		/// Provided with a token tree, eval the value of the tree based on the supplied context
		/// </summary>
		/// <param name="token"></param>
		/// <param name="context"></param>
		/// <returns></returns>
		object? Eval(IExpression token, Func<string, object> context);
		
		bool IsValidExpression(string expression);
	}
}
