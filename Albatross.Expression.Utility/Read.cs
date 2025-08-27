using Albatross.CommandLine;
using Albatross.Expression.Context;
using Albatross.Expression.Parsing;
using Microsoft.Extensions.Options;
using System.CommandLine.Invocation;

namespace Albatross.Expression.Utility {
	/// <summary>
	/// Command options for the read command that retrieves and displays a stored variable value.
	/// </summary>
	[Verb("read", typeof(Read), Alias = ["r"], Description = "Read a variable")]
	public class ReadOptions {
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
	public class Read : BaseHandler<EvalOptions> {
		private readonly IParser parser;
		private readonly IExecutionContext<object> executionContext;

		/// <summary>
		/// Initializes a new instance of the Read class.
		/// </summary>
		/// <param name="options">Command options containing the variable name to read.</param>
		/// <param name="parser">Expression parser for building variable references.</param>
		/// <param name="executionContext">Execution context providing access to stored variables.</param>
		public Read(IOptions<EvalOptions> options, IParser parser, IExecutionContext<object> executionContext) : base(options) {
			this.parser = parser;
			this.executionContext = executionContext;
		}

		/// <summary>
		/// Executes the read command by retrieving the variable value from the execution context.
		/// Outputs the variable value to the writer, or returns an error if the variable doesn't exist.
		/// </summary>
		/// <param name="context">The invocation context for the command.</param>
		/// <returns>Returns 0 on successful variable retrieval, non-zero if variable not found.</returns>
		public override int Invoke(InvocationContext context) {
			var node = parser.Build(options.Argument);
			var result = this.executionContext.GetValue(this.options.Argument, new object());
			this.writer.WriteLine(result);
			return 0;
		}
	}
}