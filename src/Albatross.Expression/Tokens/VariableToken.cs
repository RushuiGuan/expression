using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Albatross.Expression.Exceptions;

namespace Albatross.Expression.Tokens {
	public class VariableToken : IVariableToken {
		const string VariableNamePattern = @"^\s*([a-zA-Z_]+\.?[a-zA-Z0-9_]*) \b (?!\s*\() ";
		static Regex VariableNameRegex = new Regex(VariableNamePattern, RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);

		public string Name { get; private set; }
		public string Group { get { return "System"; } }
		public bool Match(string expression, int start, out int next) {
			next = expression.Length;
			if (start < expression.Length) {
				Match match = VariableNameRegex.Match(expression.Substring(start));
				if (match.Success) {
					Name = match.Groups[1].Value;
					next = start + match.Value.Length;
					return true;
				}
			}
			return false;
		}
		public override string ToString() { return Name; }
		public object Value { get; set; }
		public bool Calculated { get; set; }
		public int CompareTo(IOperandToken other) {
			throw new NotImplementedException();
		}
		public string EvalText(string format) {
			return Name;
		}
		public IToken Clone() {
			return new VariableToken() { Name = Name };
		}
		public object EvalValue(Func<string, object> context) {
			object value;
			if (context != null){
				value = context(Name);
				if (value is int || value is float || value is long || value is short || value is uint || value is decimal || value is ushort || value is ulong) {
					value = Convert.ToDouble(value);
				}
				return value;
			} else {
				return null;
				//throw new VariableNotFoundException(Name);
			}
		}
		public bool IsVariable { get { return true; } }
	}
}
