using Albatross.CommandLine;
using Albatross.CommandLine.Annotations;
using System.CommandLine;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Albatross.Expression.Utility {
	/// <summary>
	/// Command parameters for the list command that displays all stored variables.
	/// </summary>
	[Verb<List>("list", Alias = ["l"], Description = "List all variables")]
	public class ListParams {
	}

	/// <summary>
	/// Command handler for listing all stored variables in a tabular format.
	/// Reads all text files from the application directory and displays their names and values.
	/// </summary>
	public class List : BaseHandler<EvalParams> {
		private readonly ExpressionConfig config;

		/// <summary>
		/// Represents a variable name-value pair for display purposes.
		/// </summary>
		public record class ExpressionValue {
			/// <summary>
			/// Initializes a new instance of the ExpressionValue class.
			/// </summary>
			/// <param name="name">The variable name.</param>
			/// <param name="value">The variable value.</param>
			public ExpressionValue(string name, string value) {
				this.Name = name;
				this.Value = value;
			}

			/// <summary>
			/// Gets the name of the variable.
			/// </summary>
			public string Name { get; }
			
			/// <summary>
			/// Gets the value of the variable.
			/// </summary>
			public string Value { get; }
		}

		/// <summary>
		/// Initializes a new instance of the List class.
		/// </summary>
		/// <param name="parameters">Command parameters for evaluation (inherited from base handler).</param>
		/// <param name="config">Configuration providing application directory path.</param>
		public List(ParseResult result, EvalParams parameters, ExpressionConfig config) : base(result, parameters) {
			this.config = config;
		}

		/// <summary>
		/// Executes the list command by reading all variable files and displaying them in a table format.
		/// Creates the application directory if it doesn't exist and shows an empty table if no variables are found.
		/// </summary>
		/// <param name="context">The invocation context for the command.</param>
		/// <returns>Returns 0 on successful completion.</returns>
		public override Task<int> InvokeAsync(CancellationToken cancellationToken) {
			var list = new System.Collections.Generic.List<ExpressionValue>();
			if (!Directory.Exists(config.AppDirectory)) {
				Directory.CreateDirectory(config.AppDirectory);
			}
			foreach (var file in Directory.GetFiles(config.AppDirectory, "*.txt")) {
				var content = File.ReadAllText(file);
				content = content.Trim();
				var name = Path.GetFileNameWithoutExtension(file);
				this.Writer.WriteLine(new ExpressionValue(name, content));
			}
			return Task.FromResult(0);
		}
	}
}