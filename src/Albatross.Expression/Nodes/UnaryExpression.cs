using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Albatross.Expression.Nodes {
	public class UnaryExpression : IExpression {
		public UnaryExpression(string operatorName) {
			this.Name = operatorName;
		}
		public string Name { get; }
		public IExpression Operand { get; set; } = new UndefinedExpression();

		public string Text() {
			var sb = new StringBuilder();
			sb.Append(Name).Append(Operand.Text());
			return sb.ToString();
		}

		public virtual object? Eval(Func<string, object> context) {
			throw new NotSupportedException();
		}
	}
	public class UnaryExpressionFactory<T> : IExpressionFactory<T> where T : UnaryExpression, new() {
		private readonly string name;

		public UnaryExpressionFactory(string name) {
			this.name = name;
		}

		public bool TryParse(string expression, int start, out int next, [NotNullWhen(true)] out T? node) {
			node = null;
			next = expression.Length;
			if (start < expression.Length) {
				while (start < expression.Length && char.IsWhiteSpace(expression[start])) {
					start++;
				}
				if (expression.IndexOf(name, start, StringComparison.InvariantCultureIgnoreCase) == start) {
					next = start + name.Length;
					node = new T();
					return true;
				}
			}
			return false;
		}
	}
}