using System.CommandLine.Parsing;
using System.Threading.Tasks;

namespace Albatross.Expression.Utility {
	class Program {
		static async Task<int> Main(string[] args) {
			return await new MySetup().AddCommands()
						.CommandBuilder.Build()
						.InvokeAsync(args);
		}
	}
}