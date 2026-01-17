using Albatross.Expression.Exceptions;
using Albatross.Expression.Nodes;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Albatross.Expression.Infix {
	/// <summary>
	/// Base implementation for infix binary operation expressions.
	/// </summary>
	public class InfixExpression : IInfixExpression {
		/// <summary>
		/// The operator symbol for this infix operation.
		/// </summary>
		public string Operator { get; }
		
		/// <summary>
		/// The token representation, which is the same as the Operator.
		/// </summary>
		public string Token => Operator;
		
		/// <summary>
		/// The precedence level of this operation for proper evaluation order.
		/// </summary>
		public int Precedence { get; }
		
		/// <summary>
		/// Initializes a new instance of the <see cref="InfixExpression"/> class.
		/// </summary>
		/// <param name="operatorText">The operator symbol.</param>
		/// <param name="precedence">The precedence level for this operation.</param>
		public InfixExpression(string operatorText, int precedence) {
			Operator = operatorText;
			Precedence = precedence;
		}

		/// <summary>
		/// The left operand of the infix operation.
		/// </summary>
		public IExpression? Left { get; set; }
		
		/// <summary>
		/// The right operand of the infix operation.
		/// </summary>
		public IExpression? Right { get; set; }

		/// <summary>
		/// Gets the required left operand, throwing an exception if it's null.
		/// </summary>
		public IExpression RequiredLeft => Left ?? throw new OperandException($"Infix expression '{this.Operator}' is missing its left operand");
		
		/// <summary>
		/// Gets the required right operand, throwing an exception if it's null.
		/// </summary>
		public IExpression RequiredRight => Right ?? throw new OperandException($"Infix expression '{this.Operator}' is missing its right operand");

		/// <inheritdoc />
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

		/// <inheritdoc />
		public object Eval(Func<string, object> context) {
			var left = RequiredLeft.Eval(context);
			var right = RequiredRight.Eval(context);
			return Run(left, right);
		}

		/// <inheritdoc />
		public async Task<object> EvalAsync(Func<string, Task<object>> context) {
			var left = await RequiredLeft.EvalAsync(context);
			var right = await RequiredRight.EvalAsync(context);
			return Run(left, right);
		}

		/// <summary>
		/// Executes the infix operation with the evaluated left and right operands.
		/// Derived classes should override this method to implement specific operations.
		/// </summary>
		/// <param name="left">The evaluated left operand value.</param>
		/// <param name="right">The evaluated right operand value.</param>
		/// <returns>The result of the operation.</returns>
		protected virtual object Run(object left, object right) {
			throw new NotSupportedException($"Infix operation '{Operator}' is not implemented.");
		}
	}
}