using Albatross.CommandLine;
using Albatross.CommandLine.Annotations;
using System.CommandLine;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Albatross.Expression.Utility {
	/// <summary>
	/// Command parameters for the remove command that deletes a stored variable.
	/// </summary>
	[Verb<Remove>("remove", Description = "Remove a varaible")]
	public class RemoveParams {
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
	public class Remove : BaseHandler<RemoveParams> {
		private readonly ExpressionConfig config;

		public Remove(RemoveParams parameters, ParseResult result, ExpressionConfig config) : base(result, parameters) {
			this.config = config;
		}

		/// <summary>
		/// Executes the remove command by deleting the variable file if it exists.
		/// Performs a silent delete operation - no error is thrown if the variable doesn't exist.
		/// </summary>
		/// <param name="context">The invocation context for the command.</param>
		/// <returns>Returns 0 on successful completion regardless of whether the file existed.</returns>
		public override Task<int> InvokeAsync(CancellationToken cancellationToken) {
			var filePath = Path.Join(config.AppDirectory, $"{parameters.Name}.txt");
			if (File.Exists(filePath)) {
				File.Delete(filePath);
			}
			return Task.FromResult(0);
		}
	}
}