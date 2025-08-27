using Albatross.CommandLine;
using Albatross.Config;
using Albatross.Expression.Context;
using Albatross.Expression.Parsing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.CommandLine.Invocation;

namespace Albatross.Expression.Utility {
	/// <summary>
	/// Application setup class that configures dependency injection services for the Expression Utility.
	/// Registers command handlers, parsers, execution context, and configuration services.
	/// </summary>
	public class MySetup : Setup {
		/// <summary>
		/// Configures the dependency injection container with application-specific services.
		/// Registers expression parser, custom execution context, configuration, and command handlers.
		/// </summary>
		/// <param name="context">The invocation context from the command line.</param>
		/// <param name="configuration">Application configuration instance.</param>
		/// <param name="envSetting">Environment-specific settings.</param>
		/// <param name="services">Service collection to register dependencies into.</param>
		public override void RegisterServices(InvocationContext context, IConfiguration configuration, EnvironmentSetting envSetting, IServiceCollection services) {
			base.RegisterServices(context, configuration, envSetting, services);
			services.RegisterCommands();
			services.AddConfig<ExpressionConfig>();
			services.AddSingleton<IParser>(x => new ParserBuilder().BuildDefault(false));
			services.AddScoped<IExecutionContext<object>, CustomExecutionContext<object>>();
		}
	}
}
