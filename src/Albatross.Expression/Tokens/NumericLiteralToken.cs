using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Albatross.Expression.Exceptions;

namespace Albatross.Expression.Tokens {
	/// <summary>
	/// will take any numbers with decimals and without signs.
	/// </summary>
	public class NumericLiteralToken : IOperandToken {
		const string NumericPattern = @"^\s*([0-9]*\.?[0-9]+)";
		static Regex NumericPatternRegex = new Regex(NumericPattern, 
			RegexOptions.Compiled | 
			RegexOptions.Singleline | 
			RegexOptions.IgnorePatternWhitespace | 
			RegexOptions.IgnoreCase);

		internal NumericLiteralToken() { }

		public string Name { get; private set; }
		public string Group { get { return "Literal"; } }
		public bool Match(string expression, int start, out int next) {
			next = expression.Length;
			if (start < expression.Length) {
				Match match = NumericPatternRegex.Match(expression.Substring(start));
				if (match.Success) {
					Name = match.Groups[1].Value;
					next = start + match.Value.Length;
					return true;
				}
			}
			return false;
		}
		public string EvalText(string format) {
			return Name;
		}
		public override string ToString() { return Name; }


		public IToken Clone() {
			return new NumericLiteralToken() {Name = Name };
		}

		public object EvalValue(Func<string, object> context) {
			double d;
			if (double.TryParse(Name, out d)) {
				return d;
			} else {
				throw new FormatException();
			}
		}

	}
}
