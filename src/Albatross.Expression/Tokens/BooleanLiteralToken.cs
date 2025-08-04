using System;
using System.Text.RegularExpressions;

namespace Albatross.Expression.Tokens {
	/// <summary>
	/// will only take true or false, case insensitive
	/// </summary>
	public class BooleanLiteralToken : IOperandToken {
		const string BooleanPattern = @"^\s* (true|false)";

		static readonly Regex BooleanPatternRegex = new Regex(BooleanPattern,
			RegexOptions.Compiled |
			RegexOptions.Singleline |
			RegexOptions.IgnorePatternWhitespace |
			RegexOptions.IgnoreCase);

		public string Group {
			get { return "Literal"; }
		}

		public string? Name { get; private set; }

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

		public override string ToString() {
			return Name;
		}

		public string Text() {
			return Name;
		}

		public INode Clone() {
			return new BooleanLiteralToken {
				Name = this.Name,
			};
		}

		public object Eval(Func<string, object> context) {
			bool b;
			if (bool.TryParse(Name, out b)) {
				return b;
			} else {
				throw new FormatException();
			}
		}
	}
}