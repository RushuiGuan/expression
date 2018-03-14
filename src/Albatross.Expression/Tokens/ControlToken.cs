using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Albatross.Expression.Tokens {
	public class ControlToken : IToken {
		public const string LeftParenthesis_Text= "(";
		public const string RightParenthesis_Text = ")";
		public const string Comma_Text = ",";
		public const string FuncParamStart_Text = "$";	// special symbol that mark the beginning of the function parameters

		public static readonly ControlToken LeftParenthesis = new ControlToken(LeftParenthesis_Text);
		public static readonly ControlToken RightParenthesis = new ControlToken(RightParenthesis_Text);
		public static readonly ControlToken Comma = new ControlToken(Comma_Text);
		public static readonly ControlToken FuncParamStart = new ControlToken(FuncParamStart_Text);

		private ControlToken(string name) { Name = name; }
		public string Name { get; private set; }
		public string Group { get { return "System"; } }
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
			return new ControlToken(Name);
		}
		public object EvalValue(Func<string, object> context) {
			throw new NotSupportedException();
		}
		public bool IsVariable { get { return false; } }
	}
}
