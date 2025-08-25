using Albatross.CommandLine;
using Microsoft.Extensions.Options;
using System.CommandLine.Invocation;

namespace Albatross.Expression.Utility {
	[Verb("remove", typeof(Remove), Alias = ["r"], Description = "Remove a varaible")]
	public class RemoveOptions {
		[Option("n", Description = "Variable name")]
		public string Name { get; set; } = string.Empty;
	}
	public class Remove : BaseHandler<RemoveOptions> {
		public Remove(IOptions<RemoveOptions> options) : base(options) {
		}
		public override int Invoke(InvocationContext context) {
			return base.Invoke(context);
		}
	}
}
