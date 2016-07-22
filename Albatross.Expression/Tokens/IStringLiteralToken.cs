using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Albatross.Expression.Tokens {
	public interface IStringLiteralToken : IToken {
		char Boundary { get; }
	}
}
