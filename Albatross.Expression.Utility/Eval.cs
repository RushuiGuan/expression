using Albatross.CommandLine;
using Albatross.CommandLine.Annotations;
using Albatross.Expression.Context;
using Albatross.Expression.Parsing;
using System.CommandLine;
using System.Threading;
using System.Threading.Tasks;

namespace Albatross.Expression.Utility {
	/// <summary>
	/// Command parameters for the eval command that evaluates mathematical, logical, or string expressions.
	/// </summary>
	[Verb<Eval>("eval", Alias = ["e"], Description = "Eval an expression")]
	public class EvalParams {
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
	public class Eval : BaseHandler<EvalParams> {
		private readonly IParser parser;
		private readonly IExecutionContext<object> executionContext;

		public Eval(EvalParams parameters, IParser parser, ParseResult result, IExecutionContext<object> executionContext) : base(result, parameters) {
			this.parser = parser;
			this.executionContext = executionContext;
		}

		/// <summary>
		/// Executes the eval command by parsing and evaluating the provided expression.
		/// Writes the result to the output writer. Supports complex expressions with variables, functions, and operations.
		/// </summary>
		/// <param name="context">The invocation context for the command.</param>
		/// <returns>Returns 0 on successful evaluation, non-zero on parsing or evaluation errors.</returns>
		public override Task<int> InvokeAsync(CancellationToken cancellationToken) {
			var result = parser.Eval(parameters.Argument, this.executionContext, new object());
			this.Writer.WriteLine(result);
			return Task.FromResult(0);
		}
	}
}