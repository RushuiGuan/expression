using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Albatross.Expression.Tokens {
	public interface IToken {
		string Name { get; }
		bool Match(string expression, int start, out int next);
		string EvalText(string format);
		object EvalValue(Func<string, object> context);
		IToken Clone();

		bool IsVariable { get; }
	}
}
