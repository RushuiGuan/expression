using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Albatross.Expression.Nodes {
	public record class ControlToken : INode {
		public const string LeftParenthesis_Text = "(";
		public const string RightParenthesis_Text = ")";
		public const string Comma_Text = ",";
		public const string FuncParamStart_Text = "$"; // special symbol that mark the beginning of the function parameters

		public static readonly ControlToken LeftParenthesis = new(LeftParenthesis_Text);
		public static readonly ControlToken RightParenthesis = new(RightParenthesis_Text);
		public static readonly ControlToken Comma = new(Comma_Text);
		public static readonly ControlToken FuncParamStart = new(FuncParamStart_Text);

		public ControlToken(string value) { Value = value; }
		public string Value { get; }
		public string Text() => Value;
	}

	public class ControlTokenFactory : IExpressionFactory<ControlToken> {
		public ControlTokenFactory(string tokenText) {
			this.TokenText = tokenText;
		}

		public string TokenText { get; }

		public ControlToken? Parse(string text, int start, out int next) {
			next = text.Length;
			if (start < text.Length) {
				while (start < text.Length && char.IsWhiteSpace(text[start])) {
					start++;
				}

				if (text.IndexOf(TokenText, start, StringComparison.Ordinal) == start) {
					next = start + TokenText.Length;
					return new ControlToken(TokenText);
				}
			}
			return null;
		}
	}
}