using Albatross.CommandLine;
using Microsoft.Extensions.Options;
using System.CommandLine.Invocation;
using System.IO;

namespace Albatross.Expression.Utility {
	[Verb("remove", typeof(Remove), Description = "Remove a varaible")]
	public class RemoveOptions {
		[Option("n", Description = "Variable name")]
		public string Name { get; set; } = string.Empty;
	}

	public class Remove : BaseHandler<RemoveOptions> {
		private readonly ExpressionConfig config;

		public Remove(IOptions<RemoveOptions> options, ExpressionConfig config) : base(options) {
			this.config = config;
		}

		public override int Invoke(InvocationContext context) {
			var filePath = Path.Join(config.AppDirectory, $"{options.Name}.txt");
			if (File.Exists(filePath)) {
				File.Delete(filePath);
			}
			return 0;
		}
	}
}