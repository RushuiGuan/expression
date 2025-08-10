using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albatross.Expression.Utility {
	class Program {
		static Task<int> Main(string[] args) {
			return new MySetup().AddCommands()
						.CommandBuilder.Build()
						.InvokeAsync(args);
		}
	}
}
