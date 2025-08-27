using Albatross.Config;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Albatross.Expression.Utility {
	/// <summary>
	/// Configuration class for the Expression Utility application that provides application-specific settings and directory paths.
	/// </summary>
	public class ExpressionConfig : ConfigBase{
		/// <summary>
		/// Initializes a new instance of the ExpressionConfig class.
		/// </summary>
		/// <param name="configuration">The configuration instance to use for reading settings.</param>
		public ExpressionConfig(IConfiguration configuration) : base(configuration, string.Empty) {
		}
		
		/// <summary>
		/// Gets the application directory path where variables and data files are stored.
		/// Located in the user's local application data directory under "Albatross.Expression.Utility".
		/// </summary>
		public string AppDirectory => Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Albatross.Expression.Utility");
	}
}