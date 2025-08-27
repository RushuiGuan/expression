using Albatross.CommandLine;
using Microsoft.Extensions.Options;
using System.CommandLine.Invocation;
using System.IO;

namespace Albatross.Expression.Utility {
	/// <summary>
	/// Command options for the remove command that deletes a stored variable.
	/// </summary>
	[Verb("remove", typeof(Remove), Description = "Remove a varaible")]
	public class RemoveOptions {
		/// <summary>
		/// Gets or sets the name of the variable to remove.
		/// </summary>
		[Argument(Description = "Variable name")]
		public string Name { get; set; } = string.Empty;
	}

	/// <summary>
	/// Command handler for removing stored variables from the file system.
	/// Deletes the text file associated with the specified variable name.
	/// </summary>
	public class Remove : BaseHandler<RemoveOptions> {
		private readonly ExpressionConfig config;

		/// <summary>
		/// Initializes a new instance of the Remove class.
		/// </summary>
		/// <param name="options">Command options containing the variable name to remove.</param>
		/// <param name="config">Configuration providing application directory path.</param>
		public Remove(IOptions<RemoveOptions> options, ExpressionConfig config) : base(options) {
			this.config = config;
		}

		/// <summary>
		/// Executes the remove command by deleting the variable file if it exists.
		/// Performs a silent delete operation - no error is thrown if the variable doesn't exist.
		/// </summary>
		/// <param name="context">The invocation context for the command.</param>
		/// <returns>Returns 0 on successful completion regardless of whether the file existed.</returns>
		public override int Invoke(InvocationContext context) {
			var filePath = Path.Join(config.AppDirectory, $"{options.Name}.txt");
			if (File.Exists(filePath)) {
				File.Delete(filePath);
			}
			return 0;
		}
	}
}