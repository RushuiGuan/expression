using Albatross.Expression.Context;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Threading.Tasks;

namespace Albatross.Expression.Utility {
	/// <summary>
	/// Custom execution context that provides variable resolution from the file system.
	/// Extends the base ExecutionContext to load variables from text files stored in the application directory.
	/// </summary>
	/// <typeparam name="T">The type of the root context object.</typeparam>
	public class CustomExecutionContext<T>: ExecutionContext<T> {
		private readonly ExpressionConfig config;

		/// <summary>
		/// Initializes a new instance of the CustomExecutionContext class.
		/// </summary>
		/// <param name="parser">The expression parser for evaluating variable expressions.</param>
		/// <param name="config">Configuration providing the application directory path for variable storage.</param>
		public CustomExecutionContext(IParser parser, ExpressionConfig config) : base(parser) {
			this.config = config;
		}

		/// <summary>
		/// Attempts to resolve a variable value by reading from the corresponding text file.
		/// Looks for a file named "{name}.txt" in the application directory and creates an expression context value if found.
		/// </summary>
		/// <param name="name">The variable name to resolve.</param>
		/// <param name="value">When this method returns, contains the context value if the variable was found, or null if not found.</param>
		/// <returns>true if the variable file exists and was successfully loaded; otherwise, false.</returns>
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