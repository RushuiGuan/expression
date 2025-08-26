using System;

namespace Albatross.Expression.Exceptions {
	/// <summary>
	/// Exception thrown when there are issues with operands in expressions.
	/// </summary>
	public class OperandException : Exception {
		/// <summary>
		/// Initializes a new instance of the <see cref="OperandException"/> class with a specified error message.
		/// </summary>
		/// <param name="msg">The message that describes the error.</param>
		public OperandException(string msg) : base(msg) { }
	}
}
