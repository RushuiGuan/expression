using System;

namespace Albatross.Expression.Exceptions {
	public class TokenParsingException : Exception {
		public TokenParsingException(string msg) : base(msg) { }
	}
}
