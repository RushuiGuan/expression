using Albatross.CommandLine;
using Microsoft.Extensions.Options;
using System.CommandLine.Invocation;

namespace Albatross.Expression.Utility {
	[Verb("eval", typeof(Eval), Alias = ["e"], Description = "Eval an expression")]
	public class EvalOptions {
		[Argument(Description = "Expression")]
		public string Argument { get; set; } = string.Empty;
	}
	public class Eval : BaseHandler<EvalOptions> {
		public Eval(IOptions<EvalOptions> options) : base(options) {
		}
		public override int Invoke(InvocationContext context) {
			return base.Invoke(context);
		}
	}
}
