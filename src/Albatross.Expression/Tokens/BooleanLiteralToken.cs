using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Albatross.Expression.Exceptions;

namespace Albatross.Expression.Tokens {
	/// <summary>
	/// will only take true or false, case insensitive
	/// </summary>
	public class BooleanLiteralToken : IOperandToken {
		const string BooleanPattern = @"^\s* (true|false)";
		static Regex BooleanPatternRegex = new Regex(BooleanPattern,
			RegexOptions.Compiled |
			RegexOptions.Singleline |
			RegexOptions.IgnorePatternWhitespace |
			RegexOptions.IgnoreCase);

		internal BooleanLiteralToken() { }
		public string Group { get { return "Literal"; } }
		public string Name { get; private set; }
		public bool Match(string expression, int start, out int next) {
			next = expression.Length;
			if (start < expression.Length) {
				Match match = BooleanPatternRegex.Match(expression.Substring(start));
				if (match.Success) {
					Name = match.Groups[1].Value;
					next = start + match.Value.Length;
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
			return new BooleanLiteralToken() { Name = Name };
		}

		public object EvalValue(Func<string, object> context) {
			bool b;
			if (bool.TryParse(Name, out b)) {
				return b;
			} else {
				throw new FormatException();
			}
		}
		public bool IsVariable { get { return false; } }
	}
}