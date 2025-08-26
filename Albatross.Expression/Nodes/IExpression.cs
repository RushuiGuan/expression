using System;
using System.Threading.Tasks;

namespace Albatross.Expression.Nodes {
	/// <summary>
	/// Represents an evaluable expression that can be executed with a given context.
	/// </summary>
	public interface IExpression : IToken{
		/// <summary>
		/// Evaluates the expression synchronously using the provided context function.
		/// </summary>
		/// <param name="context">A function that resolves variable names to their values.</param>
		/// <returns>The result of evaluating the expression.</returns>
		object Eval(Func<string, object> context);
		
		/// <summary>
		/// Evaluates the expression asynchronously using the provided context function.
		/// </summary>
		/// <param name="context">A function that asynchronously resolves variable names to their values.</param>
		/// <returns>A task containing the result of evaluating the expression.</returns>
		Task<object> EvalAsync(Func<string, Task<object>> context);
	}
}
