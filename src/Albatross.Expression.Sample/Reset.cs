using Albatross.CommandLine;
using Microsoft.Extensions.Options;
using System.CommandLine.Invocation;

namespace Albatross.Expression.Utility {
	[Verb("reset", typeof(Reset), Alias = ["reset"], Description = "Reset the session by deleting all variables")]
	public class ResetOptions { }
	public class Reset : BaseHandler<ResetOptions> {
		public Reset(IOptions<ResetOptions> options) : base(options) {
		}
		public override int Invoke(InvocationContext context) {
			return base.Invoke(context);
		}
	}
}
