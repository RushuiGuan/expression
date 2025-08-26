using Albatross.Expression.Context;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Threading.Tasks;

namespace Albatross.Expression.Utility {
	public class CustomExecutionContext<T>: ExecutionContext<T> {
		private readonly ExpressionConfig config;

		public CustomExecutionContext(IParser parser, ExpressionConfig config) : base(parser) {
			this.config = config;
		}

		protected override bool TryGetValueHandler(string name, [NotNullWhen(true)] out IContextValue<T>? value) {
			var file = Path.Join(config.AppDirectory, $"{name}.txt");
			if (File.Exists(file)) {
				var expression = File.ReadAllText(file).Trim();
				value = new ExpressionContextValue<T>(name, expression, Parser);
				return true;
			}else{
				value = null;
				return false;
			}
		}
	}
}