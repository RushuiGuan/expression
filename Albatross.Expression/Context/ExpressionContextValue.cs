using Albatross.Expression.Nodes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Albatross.Expression.Context {
	/// <summary>
	/// Context value that represents a variable defined by an expression.
	/// Parses the expression into an abstract syntax tree and evaluates it dynamically when requested.
	/// </summary>
	/// <typeparam name="T">The type of the root context object.</typeparam>
	public class ExpressionContextValue<T> : IContextValue<T> {
		/// <summary>
		/// Initializes a new instance of the ExpressionContextValue class.
		/// Parses the expression, identifies variable dependencies, and builds the evaluation tree.
		/// </summary>
		/// <param name="name">The name of this context value.</param>
		/// <param name="expression">The expression string to parse and evaluate.</param>
		/// <param name="parser">The parser to use for tokenizing and building the expression tree.</param>
		public ExpressionContextValue(string name, string expression, IParser parser) {
			Name = name;
			this.Expression = expression;
			Dependees = parser.CaseSensitive ? new HashSet<string>() : new HashSet<string>(StringComparer.OrdinalIgnoreCase);
			var queue = parser.Tokenize(expression);
			foreach (var token in queue) {
				if (token is Variable variable) {
					Dependees.Add(variable.Value);
				}
			}
			var stack = parser.BuildPostfixStack(queue);
			this.Tree = parser.CreateTree(stack);
		}

		/// <summary>
		/// Gets the name of this context value.
		/// </summary>
		public string Name { get; }
		
		/// <summary>
		/// Evaluates the expression tree to get the current value.
		/// Uses the provided function to resolve variable references during evaluation.
		/// </summary>
		/// <param name="input">The root context object.</param>
		/// <param name="func">Function to resolve variable values during evaluation.</param>
		/// <returns>The result of evaluating the expression.</returns>
		public object GetValue(T input, Func<string, T, object> func) 
			=>  this.Tree.Eval(name=> func(name, input));

		/// <summary>
		/// Asynchronously evaluates the expression tree to get the current value.
		/// Uses the provided async function to resolve variable references during evaluation.
		/// </summary>
		/// <param name="input">The root context object.</param>
		/// <param name="func">Async function to resolve variable values during evaluation.</param>
		/// <returns>A task representing the asynchronous evaluation operation.</returns>
		public Task<object> GetValueAsync(T input, Func<string, T, Task<object>> func) {
			return this.Tree.EvalAsync(async name => await func(name, input));
		}

		/// <summary>
		/// Gets the original expression string used to create this context value.
		/// </summary>
		public string Expression { get; }
		
		/// <summary>
		/// Gets the parsed expression tree ready for evaluation.
		/// </summary>
		public IExpression Tree { get; }
		
		/// <summary>
		/// Gets the set of variable names that this expression depends on.
		/// Used for dependency tracking and circular reference detection.
		/// </summary>
		public ISet<string> Dependees { get; }
	}
}