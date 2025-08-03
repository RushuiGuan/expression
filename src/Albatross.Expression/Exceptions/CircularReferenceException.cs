using System;

namespace Albatross.Expression.Exceptions {
	public class CircularReferenceException : Exception {
		public CircularReferenceException(string from, string to) : base($"Circular Reference from {from} to {to}") { }
	}
}
