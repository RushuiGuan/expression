using Albatross.CommandLine;
using Albatross.Expression.Parsing;
using Microsoft.Extensions.Options;
using System.CommandLine.Invocation;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Albatross.Expression.Utility {
	/// <summary>
	/// Command options for the set command that stores a variable with name and value.
	/// </summary>
	[Verb("set", typeof(Set), Alias = ["s"], Description = "Set a varaible")]
	public class SetOptions {
		/// <summary>
		/// Gets or sets the name of the variable to store.
		/// </summary>
		[Option("n", Description = "Variable name")]
		public string Name { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets the expression value to store for the variable.
		/// </summary>
		[Option("v", Description = "Variable expression")]
		public string Value { get; set; } = string.Empty;
	}

	/// <summary>
	/// Command validation logic for the set command that ensures variable names are valid.
	/// </summary>
	public partial class SetCommand : IRequireInitialization {
		/// <summary>
		/// Initializes validation rules for the set command to verify variable name format.
		/// </summary>
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

	/// <summary>
	/// Command handler for storing variables to the file system. Creates a text file for each variable
	/// in the application directory with the variable name as filename and value as content.
	/// </summary>
	public class Set : BaseHandler<SetOptions> {
		private readonly ExpressionConfig config;

		/// <summary>
		/// Initializes a new instance of the Set class.
		/// </summary>
		/// <param name="config">Configuration providing application directory path.</param>
		/// <param name="options">Command options containing variable name and value.</param>
		public Set(ExpressionConfig config, IOptions<SetOptions> options) : base(options) {
			this.config = config;
		}

		/// <summary>
		/// Executes the set command by writing the variable value to a text file.
		/// Creates the application directory if it doesn't exist and overwrites any existing variable with the same name.
		/// </summary>
		/// <param name="context">The invocation context for the command.</param>
		/// <returns>A task representing the asynchronous operation. Returns 0 on success.</returns>
		public override async Task<int> InvokeAsync(InvocationContext context) {
			if (!Directory.Exists(config.AppDirectory)) {
				Directory.CreateDirectory(config.AppDirectory);
			}
			var file = Path.Join(config.AppDirectory, $"{options.Name}.txt");
			await using var stream = File.OpenWrite(file);
			await using var streamWriter = new StreamWriter(stream);
			await streamWriter.WriteLineAsync(options.Value);
			return 0;
		}
	}
}