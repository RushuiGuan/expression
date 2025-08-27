using System.CommandLine.Parsing;
using System.Threading.Tasks;

namespace Albatross.Expression.Utility {
	/// <summary>
	/// Main entry point for the Albatross Expression Utility command-line application.
	/// Provides commands for evaluating expressions and managing variables.
	/// </summary>
	class Program {
		/// <summary>
		/// Application entry point that configures and executes the command-line interface.
		/// Sets up dependency injection, registers commands, and processes command-line arguments.
		/// </summary>
		/// <param name="args">Command-line arguments passed to the application.</param>
		/// <returns>A task representing the asynchronous operation, with exit code 0 for success or non-zero for errors.</returns>
		static async Task<int> Main(string[] args) {
			return await new MySetup().AddCommands()
						.CommandBuilder.Build()
						.InvokeAsync(args);
		}
	}
}