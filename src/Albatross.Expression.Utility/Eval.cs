using Albatross.CommandLine;
using Albatross.Expression.Context;
using Albatross.Expression.Parsing;
using Microsoft.Extensions.Options;
using System.CommandLine.Invocation;

namespace Albatross.Expression.Utility {
	[Verb("eval", typeof(Eval), Alias = ["e"], Description = "Eval an expression")]
	public class EvalOptions {
		[Argument(Description = "Expression")]
		public string Argument { get; set; } = string.Empty;
	}

	public class Eval : BaseHandler<EvalOptions> {
		private readonly IParser parser;
		private readonly IExecutionContext<object> executionContext;

		public Eval(IOptions<EvalOptions> options, IParser parser, IExecutionContext<object> executionContext) : base(options) {
			this.parser = parser;
			this.executionContext = executionContext;
		}

		public override int Invoke(InvocationContext context) {
			var node = parser.Build(options.Argument);
			var obj = new object();
			var result = node.Eval(name => this.executionContext.GetValue(name, obj));
			this.writer.WriteLine(result);
			return 0;
		}
	}
}