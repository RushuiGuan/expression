using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Albatross.Expression.Nodes {
	public abstract class InfixExpression : IExpression {
		public abstract string Operator { get; }
		public abstract int Precedence { get; }

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

		public abstract object? Eval(Func<string, object> context);
	}

	public class InfixExpressionFactory<T> : IExpressionFactory<T> where T : InfixExpression, new() {
		public bool TryParse(string text, int start, out int next, [NotNullWhen(true)] out T? node) {
			next = text.Length;
			if (start < text.Length) {
				while (start < text.Length && char.IsWhiteSpace(text[start])) {
					start++;
				}
				var t = new T();
				if (text.IndexOf(t.Operator, start, StringComparison.InvariantCultureIgnoreCase) == start) {
					next = start + t.Operator.Length;
					node = t;
					return true;
				}
			}
			node = null;
			return false;
		}
	}
}