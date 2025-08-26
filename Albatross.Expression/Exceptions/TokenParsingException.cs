using System;

namespace Albatross.Expression.Exceptions {
	/// <summary>
	/// Exception thrown when token parsing fails during expression analysis.
	/// </summary>
	public class TokenParsingException : Exception {
		/// <summary>
		/// Initializes a new instance of the <see cref="TokenParsingException"/> class with a specified error message.
		/// </summary>
		/// <param name="msg">The message that describes the error.</param>
		public TokenParsingException(string msg) : base(msg) { }
	}
}
