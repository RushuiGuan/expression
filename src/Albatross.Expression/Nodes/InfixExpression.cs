using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Albatross.Expression.Nodes {
	public class InfixExpression : IExpression {
		public string Operator { get; }
		public int Precedence { get; }
		
		public InfixExpression(string operatorText, int precedence) {
			Operator = operatorText;
			Precedence = precedence;
		}

		public IExpression Operand1 { get; set; } = new UndefinedExpression();
		public IExpression Operand2 { get; set; } = new UndefinedExpression();

		public string Text() {
			var sb = new StringBuilder();
			if (Operand1 is InfixExpression infix1 && infix1.Precedence < Precedence) {
				sb.Append($"({Operand1.Text()})");
			} else {
				sb.Append(Operand1.Text());
			}
			sb.Append(' ').Append(Operator).Append(' ');
			if (Operand2 is InfixExpression infix2 && infix2.Precedence <= Precedence) {
				sb.Append($"({Operand2.Text()})");
			} else {
				sb.Append(Operand2.Text());
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