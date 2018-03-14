using Albatross.Expression.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;

namespace Albatross.Expression {
	public interface IParser {
		Queue<IToken> Tokenize(string expression);
		Stack<IToken> BuildStack(Queue<IToken> queue);
		IToken CreateTree(Stack<IToken> postfix);
		object Eval(IToken token, Func<string, object> context);
		IParser Add(IToken operation);
		IToken Compile(string expression);
		
		IToken VariableToken();
		IStringLiteralToken StringLiteralToken();

		IParser SetVariableToken(IToken token);
		IParser SetStringLiteralToken(IStringLiteralToken token);
		bool IsValidExpression(string expression);

	}
}
