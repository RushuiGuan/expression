using Albatross.CommandLine;
using Albatross.Expression.Context;
using Albatross.Expression.Parsing;
using Microsoft.Extensions.Options;
using System.CommandLine.Invocation;

namespace Albatross.Expression.Utility {
	[Verb("read", typeof(Read), Alias = ["r"], Description = "Read a variable")]
	public class ReadOptions {
		[Argument(Description = "Name of the variable")]
		public string Argument { get; set; } = string.Empty;
	}

	public class Read : BaseHandler<EvalOptions> {
		private readonly IParser parser;
		private readonly IExecutionContext<object> executionContext;

		public Read(IOptions<EvalOptions> options, IParser parser, IExecutionContext<object> executionContext) : base(options) {
			this.parser = parser;
			this.executionContext = executionContext;
		}

		public override int Invoke(InvocationContext context) {
			var node = parser.Build(options.Argument);
			var result = this.executionContext.GetValue(this.options.Argument, new object());
			this.writer.WriteLine(result);
			return 0;
		}
	}
}