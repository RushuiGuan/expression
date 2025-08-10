using System.Threading.Tasks;
using System;

namespace Albatross.Expression.Utility {
	public class MySetup : Setup {
		public override void RegisterServices(InvocationContext context, IConfiguration configuration, EnvironmentSetting envSetting, IServiceCollection services) {
			base.RegisterServices(context, configuration, envSetting, services);
			services.RegisterCommands()
				.AddSecMasterProxy()
				.AddPortfolioManagementProxy()
				.AddBloombergProxy()
				.AddNotificationProxy();
		}
		public override CommandLineBuilder ConfigureBuilder() {
			this.CommandBuilder.AddMiddleware(AppInit);
			return base.ConfigureBuilder();
		}

		private Task AppInit(InvocationContext context, Func<InvocationContext, Task> next) {
			TableOptionFactory.Instance.Register(
				new TableOptionBuilder<MarketHourDto>().SetColumnsByReflection()
				.Ignore(x => x.TimeZoneInfo)
				.Ignore(x => x.MarketId)
			);
			return next(context);
		}
	}
}
