using System;

namespace Albatross.Expression.Nodes {
	public class Assignment : INode {
		const string Operator = "=";

		public bool Match(string expression, int start, out int next) {
			next = expression.Length;
			if (start < expression.Length) {
				while (start < expression.Length && char.IsWhiteSpace(expression[start])) {
					start++;
				}
				if (expression.IndexOf(Operator, start, StringComparison.InvariantCultureIgnoreCase) == start) {
					next = start + Operator.Length;
					return true;
				}
			}
			return false;
		}
		public string Text() => Operator;
	}
}