using Albatross.CommandLine;
using Microsoft.Extensions.Options;
using System.CommandLine.Invocation;

namespace Albatross.Expression.Utility {
	[Verb("add", typeof(Add), Alias = ["a"], Description = "Add a varaible")]
	public class AddOptions {
		[Option("n", Description = "Variable name")]
		public string Name { get; set; } = string.Empty;

		[Argument(Description = "Value expression")]
		public string Argument { get; set; } = string.Empty;
	}
	public class Add : BaseHandler<AddOptions> {
		public Add(IOptions<AddOptions> options) : base(options) {
		}
		public override int Invoke(InvocationContext context) {
			return base.Invoke(context);
		}
	}
}
