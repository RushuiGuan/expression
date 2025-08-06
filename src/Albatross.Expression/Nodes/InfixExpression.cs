using Albatross.Expression.Exceptions;
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

		public IExpression? Left { get; set; }
		public IExpression? Right { get; set; }

		public IExpression RequiredLeft => Left ?? throw new OperandException($"Infix expression '{this.Operator}' is missing its left operand");
		public IExpression RequiredRight => Right ?? throw new OperandException($"Infix expression '{this.Operator}' is missing its right operand");

		public string Text() {
			var sb = new StringBuilder();
			if (Left is InfixExpression left && left.Precedence < Precedence) {
				sb.Append($"({Left.Text()})");
			} else {
				sb.Append(RequiredLeft.Text());
			}
			sb.Append(' ').Append(Operator).Append(' ');
			if (Right is InfixExpression right && right.Precedence <= Precedence) {
				sb.Append($"({Right.Text()})");
			} else {
				sb.Append(RequiredRight.Text());
			}
			return sb.ToString();
		}

		public virtual object Eval(Func<string, object> context) {
			throw new NotSupportedException();
		}
	}
}