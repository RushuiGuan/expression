using System;

namespace Albatross.Expression.Exceptions {
	/// <summary>
	/// Exception thrown when there are issues with the expression evaluation stack.
	/// </summary>
	public class StackException : Exception {
		/// <summary>
		/// Initializes a new instance of the <see cref="StackException"/> class with a specified error message.
		/// </summary>
		/// <param name="msg">The message that describes the error.</param>
		public StackException(string msg) : base(msg) { }
	}
}
