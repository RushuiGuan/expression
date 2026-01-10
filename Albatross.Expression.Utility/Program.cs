using Albatross.CommandLine;
using Albatross.CommandLine.Defaults;
using Albatross.Config;
using Albatross.Expression.Context;
using Albatross.Expression.Parsing;
using Microsoft.Extensions.DependencyInjection;
using System.CommandLine;
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
			await using var host = new CommandHost("Albatross Expression Utility")
				.RegisterServices(RegisterServices)
				.AddCommands()
				.Parse(args)
				.WithDefaults()
				.Build();
			return await host.InvokeAsync();
		}

		static void RegisterServices(ParseResult result, IServiceCollection services) {
			services.RegisterCommands();
			services.AddConfig<ExpressionConfig>();
			services.AddSingleton<IParser>(x => new ParserBuilder().BuildDefault(false));
			services.AddScoped<IExecutionContext<object>, CustomExecutionContext<object>>();
		}
	}
}