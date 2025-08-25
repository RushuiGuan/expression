using Albatross.Expression.Exceptions;
using Albatross.Expression.Nodes;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Albatross.Expression.Infix {
	public class InfixExpression : IInfixExpression {
		public string Operator { get; }
		public string Token => Operator;
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

		public object Eval(Func<string, object> context) {
			var left = RequiredLeft.Eval(context);
			var right = RequiredRight.Eval(context);
			return Run(left, right);
		}

		public async Task<object> EvalAsync(Func<string, Task<object>> context) {
			var left = await RequiredLeft.EvalAsync(context);
			var right = await RequiredRight.EvalAsync(context);
			return Run(left, right);
		}

		public virtual object Run(object left, object right) {
			throw new NotSupportedException($"Infix operation '{Operator}' is not implemented.");
		}
	}
}