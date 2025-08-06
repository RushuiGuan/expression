using System;
using System.Text;

namespace Albatross.Expression.Nodes {
	public class InfixExpression : IExpression {
		public string Operator { get; }
		public int Precedence { get; }
		
		public InfixExpression(string operatorText, int precedence) {
			Operator = operatorText;
			Precedence = precedence;
		}

		public IExpression Left { get; set; } = new UndefinedExpression();
		public IExpression Right { get; set; } = new UndefinedExpression();

		public string Text() {
			var sb = new StringBuilder();
			if (Left is InfixExpression left && left.Precedence < Precedence) {
				sb.Append($"({Left.Text()})");
			} else {
				sb.Append(Left.Text());
			}
			sb.Append(' ').Append(Operator).Append(' ');
			if (Right is InfixExpression right && right.Precedence <= Precedence) {
				sb.Append($"({Right.Text()})");
			} else {
				sb.Append(Right.Text());
			}
			return sb.ToString();
		}

		public virtual object? Eval(Func<string, object> context) {
			throw new NotSupportedException();
		}
	}

	public class InfixExpressionFactory<T> : IExpressionFactory<T> where T : InfixExpression, new() {
		private readonly bool caseSensitive;

		public InfixExpressionFactory(bool caseSensitive) {
			this.caseSensitive = caseSensitive;
		}

		public T? Parse(string text, int start, out int next) {
			next = text.Length;
			if (start < text.Length) {
				while (start < text.Length && char.IsWhiteSpace(text[start])) {
					start++;
				}
				var t = new T();
				var index = caseSensitive
					? text.IndexOf(t.Operator, start, StringComparison.Ordinal)
					: text.IndexOf(t.Operator, start, StringComparison.InvariantCultureIgnoreCase);
				if (index == start) {
					next = start + t.Operator.Length;
					return t;
				}
			}
			return null;
		}
	}
}