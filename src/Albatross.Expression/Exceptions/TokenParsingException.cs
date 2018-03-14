using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Albatross.Expression.Exceptions {
	public class TokenParsingException : Exception {
		public TokenParsingException(string msg) : base(msg) { }
	}
}
