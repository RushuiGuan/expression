using System;

namespace Albatross.Expression.Nodes {
	public interface IExpression : IToken{
		object Eval(Func<string, object> context);
	}
}
