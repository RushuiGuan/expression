using System;

namespace Albatross.Expression.Tokens {
	public class AssignmentToken : IToken {
		public string Name => "=";
		public bool Match(string expression, int start, out int next) {
			next = expression.Length;
			if (start < expression.Length) {
				while (start < expression.Length && char.IsWhiteSpace(expression[start])) {
					start++;
				}
				if (expression.IndexOf(Name, start, StringComparison.InvariantCultureIgnoreCase) == start) {
					next = start + Name.Length;
					return true;
				}
			}
			return false;
		}
		public override string ToString() { return Name; }
		public string EvalText(string format) {
			return Name;
		}
		public IToken Clone() {
			return new AssignmentToken();
		}
		public object EvalValue(Func<string, object> context) {
			throw new NotSupportedException();
		}

	}
}
