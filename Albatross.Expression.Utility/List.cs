using Albatross.Text.Table;
using Albatross.CommandLine;
using Microsoft.Extensions.Options;
using System.CommandLine.Invocation;
using System.IO;

namespace Albatross.Expression.Utility {
	[Verb("list", typeof(List), Alias = ["l"], Description = "List all variables")]
	public class ListOptions {
	}

	public class List : BaseHandler<EvalOptions> {
		private readonly ExpressionConfig config;

		public class ExpressionValue {
			public ExpressionValue(string name, string value) {
				this.Name = name;
				this.Value = value;
			}
			public string Name { get; }
			public string Value { get; }
		}

		public List(IOptions<EvalOptions> options, ExpressionConfig config) : base(options) {
			this.config = config;
		}

		public override int Invoke(InvocationContext context) {
			var list = new System.Collections.Generic.List<ExpressionValue>();
			foreach(var file in Directory.GetFiles(config.AppDirectory, "*.txt")) {
				var content = File.ReadAllText(file);
				content = content.Trim();
				var name = Path.GetFileNameWithoutExtension(file);
				list.Add(new ExpressionValue(name, content));
			}
			list.StringTable().PrintConsole();
			return 0;
		}
	}
}