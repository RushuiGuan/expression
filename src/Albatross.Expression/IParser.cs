using Albatross.Expression.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;

namespace Albatross.Expression {
	/// <summary>
	/// The interface contains functionalities to process an expression string.
	/// </summary>
	public interface IParser {
		Queue<IToken> Tokenize(string expression);
		Stack<IToken> BuildStack(Queue<IToken> queue);
		IToken CreateTree(Stack<IToken> postfix);
		object? Eval(IToken token, Func<string, object> context);
		
		IToken VariableToken();
		IStringLiteralToken StringLiteralToken();
		bool IsValidExpression(string expression);
	}
}
