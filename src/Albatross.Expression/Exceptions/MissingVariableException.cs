using System;

namespace Albatross.Expression.Exceptions {
	public class MissingVariableException : Exception {
		public MissingVariableException(string name) 
			: base($"Variable {name} was not found") {
			
			VariableName = name;
		}
		public string VariableName { get; private set; }
	}
}
