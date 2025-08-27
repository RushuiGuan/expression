using Albatross.CommandLine;
using Albatross.Expression.Context;
using Albatross.Expression.Parsing;
using Microsoft.Extensions.Options;
using System.CommandLine.Invocation;

namespace Albatross.Expression.Utility {
	/// <summary>
	/// Command options for the eval command that evaluates mathematical, logical, or string expressions.
	/// </summary>
	[Verb("eval", typeof(Eval), Alias = ["e"], Description = "Eval an expression")]
	public class EvalOptions {
		/// <summary>
		/// Gets or sets the expression string to evaluate.
		/// </summary>
		[Argument(Description = "Expression")]
		public string Argument { get; set; } = string.Empty;
	}

	/// <summary>
	/// Command handler for evaluating expressions using the Albatross.Expression parser.
	/// Supports mathematical, logical, string operations, date/time functions, and variable references.
	/// </summary>
	public class Eval : BaseHandler<EvalOptions> {
		private readonly IParser parser;
		private readonly IExecutionContext<object> executionContext;

		/// <summary>
		/// Initializes a new instance of the Eval class.
		/// </summary>
		/// <param name="options">Command options containing the expression to evaluate.</param>
		/// <param name="parser">Expression parser for tokenizing and evaluating expressions.</param>
		/// <param name="executionContext">Execution context providing variable scope and built-in functions.</param>
		public Eval(IOptions<EvalOptions> options, IParser parser, IExecutionContext<object> executionContext) : base(options) {
			this.parser = parser;
			this.executionContext = executionContext;
		}

		/// <summary>
		/// Executes the eval command by parsing and evaluating the provided expression.
		/// Writes the result to the output writer. Supports complex expressions with variables, functions, and operations.
		/// </summary>
		/// <param name="context">The invocation context for the command.</param>
		/// <returns>Returns 0 on successful evaluation, non-zero on parsing or evaluation errors.</returns>
		public override int Invoke(InvocationContext context) {
			var result = parser.Eval(options.Argument, this.executionContext, new object());
			this.writer.WriteLine(result);
			return 0;
		}
	}
}