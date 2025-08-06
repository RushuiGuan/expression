using System;

namespace Albatross.Expression.Nodes {
	public interface IExpression : INode{
		object Eval(Func<string, object> context);
	}
}
