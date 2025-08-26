using Albatross.CommandLine;
using Albatross.Config;
using Albatross.Expression.Context;
using Albatross.Expression.Parsing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.CommandLine.Invocation;

namespace Albatross.Expression.Utility {
	public class MySetup : Setup {
		public override void RegisterServices(InvocationContext context, IConfiguration configuration, EnvironmentSetting envSetting, IServiceCollection services) {
			base.RegisterServices(context, configuration, envSetting, services);
			services.RegisterCommands();
			services.AddConfig<ExpressionConfig>();
			services.AddSingleton<IParser>(x => new ParserBuilder().BuildDefault(false));
			services.AddScoped<IExecutionContext<object>, CustomExecutionContext<object>>();
		}
	}
}
