using System;

namespace Albatross.Expression.Exceptions {
	/// <summary>
	/// Exception thrown when a required variable is not found in the execution context.
	/// </summary>
	public class MissingVariableException: Exception {
		/// <summary>
		/// Initializes a new instance of the <see cref="MissingVariableException"/> class.
		/// </summary>
		/// <param name="name">The name of the missing variable.</param>
		public MissingVariableException(string name)
			: base($"The variable '{name}' is missing in the context.") {
		}
	}
}