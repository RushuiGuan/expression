using System;
using System.Threading.Tasks;

namespace Albatross.Expression.Nodes {
	public interface IExpression : IToken{
		object Eval(Func<string, object> context);
		Task<object> EvalAsync(Func<string, Task<object>> context);
	}
}
