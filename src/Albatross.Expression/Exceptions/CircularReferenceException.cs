using System;

namespace Albatross.Expression.Exceptions {
	/// <summary>
	/// Exception thrown when a circular reference is detected in variable dependencies.
	/// </summary>
	public class CircularReferenceException : Exception {
		/// <summary>
		/// Initializes a new instance of the <see cref="CircularReferenceException"/> class.
		/// </summary>
		/// <param name="from">The source variable that causes the circular reference.</param>
		/// <param name="to">The target variable that completes the circular reference.</param>
		public CircularReferenceException(string from, string to) : base($"Circular Reference from {from} to {to}") { }
	}
}
