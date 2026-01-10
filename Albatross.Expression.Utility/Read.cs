using Albatross.CommandLine;
using Albatross.CommandLine.Annotations;
using Albatross.Expression.Context;
using Albatross.Expression.Parsing;
using System.CommandLine;
using System.Threading;
using System.Threading.Tasks;

namespace Albatross.Expression.Utility {
	/// <summary>
	/// Command parameters for the read command that retrieves and displays a stored variable value.
	/// </summary>
	[Verb<Read>("read", Alias = ["r"], Description = "Read a variable")]
	public class ReadParams {
		/// <summary>
		/// Gets or sets the name of the variable to read.
		/// </summary>
		[Argument(Description = "Name of the variable")]
		public string Argument { get; set; } = string.Empty;
	}

	/// <summary>
	/// Command handler for reading and displaying stored variable values.
	/// Retrieves a variable from the execution context and outputs its current value.
	/// </summary>
	public class Read : BaseHandler<EvalParams> {
		private readonly IParser parser;
		private readonly IExecutionContext<object> executionContext;

		public Read(EvalParams parameters, IParser parser, ParseResult result, IExecutionContext<object> executionContext) : base(result, parameters) {
			this.parser = parser;
			this.executionContext = executionContext;
		}

		/// <summary>
		/// Executes the read command by retrieving the variable value from the execution context.
		/// Outputs the variable value to the writer, or returns an error if the variable doesn't exist.
		/// </summary>
		/// <param name="context">The invocation context for the command.</param>
		/// <returns>Returns 0 on successful variable retrieval, non-zero if variable not found.</returns>
		public override Task<int> InvokeAsync(CancellationToken cancellationToken) {
			var node = parser.Build(parameters.Argument);
			var result = this.executionContext.GetValue(this.parameters.Argument, new object());
			this.Writer.WriteLine(result);
			return Task.FromResult(0);
		}
	}
}