using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Albatross.Expression.Prefix {
	/// <summary>
	/// Prefix expression that combines multiple path segments into a single file system path.
	/// Takes one or more string parameters and joins them using the appropriate path separator.
	/// </summary>
	public class JoinPath : PrefixExpression {
		/// <summary>
		/// Initializes a new instance of the JoinPath class with name "JoinPath" and variable parameter count (minimum 1).
		/// </summary>
		public JoinPath() : base("JoinPath", 1, int.MaxValue) { }
		
		/// <summary>
		/// Combines multiple path segments into a single path string using the platform-appropriate path separator.
		/// All operands are converted to strings before joining.
		/// </summary>
		/// <param name="operands">List containing one or more path segment operands to join.</param>
		/// <returns>A combined file system path string with proper separators for the current platform.</returns>
		protected override object Run(List<object> operands) {
			return Path.Join(operands.Select(x=>x.ConvertToString()).ToArray());
		}
	}
}