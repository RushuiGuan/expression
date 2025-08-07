using System;

namespace Albatross.Expression.Exceptions {
	public class MissingVariableException: Exception {
	public MissingVariableException(string name)
			: base($"The variable '{name}' is missing in the context.") {
		}
	}
}