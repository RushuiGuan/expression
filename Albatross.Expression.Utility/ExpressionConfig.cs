using Albatross.Config;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Albatross.Expression.Utility {
	public class ExpressionConfig : ConfigBase{
		public ExpressionConfig(IConfiguration configuration) : base(configuration, string.Empty) {
		}
		public string AppDirectory => Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Albatross.Expression.Utility");
	}
}