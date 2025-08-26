using Albatross.CommandLine;
using Albatross.Expression.Parsing;
using Microsoft.Extensions.Options;
using System.CommandLine.Invocation;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Albatross.Expression.Utility {
	[Verb("set", typeof(Set), Alias = ["a"], Description = "Set a varaible")]
	public class SetOptions {
		[Option("n", Description = "Variable name")]
		public string Name { get; set; } = string.Empty;

		[Argument(Description = "Value expression")]
		public string Argument { get; set; } = string.Empty;
	}

	public partial class SetCommand : IRequireInitialization {
		public void Init() {
			this.AddValidator(result => {
				var symbol = result.Children.First(x => x.Symbol == this.Option_Name);
				var value = symbol.GetValueForOption(this.Option_Name);
				if (!VariableFactory.VariableNameRegex.IsMatch(value ?? "")) {
					result.ErrorMessage = $"Invalid variable name '{value}'";
				}
			});
		}
	}

	public class Set : BaseHandler<SetOptions> {
		private readonly ExpressionConfig config;

		public Set(ExpressionConfig config, IOptions<SetOptions> options) : base(options) {
			this.config = config;
		}

		public override async Task<int> InvokeAsync(InvocationContext context) {
			if (!Directory.Exists(config.AppDirectory)) {
				Directory.CreateDirectory(config.AppDirectory);
			}
			var file = Path.Join(config.AppDirectory, $"{options.Name}.txt");
			await using var stream = File.OpenWrite(file);
			await using var streamWriter = new StreamWriter(stream);
			await streamWriter.WriteLineAsync(options.Argument);
			return 0;
		}
	}
}