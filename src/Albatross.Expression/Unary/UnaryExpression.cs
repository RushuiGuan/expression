using Albatross.Expression.Exceptions;
using Albatross.Expression.Nodes;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Albatross.Expression.Unary {
	/// <summary>
	/// Base implementation for unary operation expressions that operate on a single operand.
	/// </summary>
	public class UnaryExpression : IUnaryExpression {
		/// <summary>
		/// Initializes a new instance of the <see cref="UnaryExpression"/> class.
		/// </summary>
		/// <param name="operatorOperator">The operator symbol.</param>
		/// <param name="precedence">The precedence level for this operation.</param>
		public UnaryExpression(string operatorOperator, int precedence) {
			Operator = operatorOperator;
			Precedence = precedence;
		}

		/// <summary>
		/// The precedence level of this operation for proper evaluation order.
		/// </summary>
		public int Precedence { get; }
		
		/// <summary>
		/// The operator symbol for this unary operation.
		/// </summary>
		public string Operator { get; }
		
		/// <summary>
		/// The token representation, which is the same as the Operator.
		/// </summary>
		public string Token => Operator;
		
		/// <summary>
		/// The operand that this unary operation applies to.
		/// </summary>
		public IExpression? Operand { get; set; }
		
		/// <summary>
		/// Gets the required operand, throwing an exception if it's null.
		/// </summary>
		public IExpression RequiredOperand => Operand ?? throw new OperandException($"Unary expression '{Operator}' is missing its operand");

		public string Text() {
			var sb = new StringBuilder();
			sb.Append(Operator).Append(RequiredOperand.Text());
			return sb.ToString();
		}

		public object Eval(Func<string, object> context) {
			var value = RequiredOperand.Eval(context);
			return Run(value);
		}

		public async Task<object> EvalAsync(Func<string, Task<object>> context) {
			var value = await RequiredOperand.EvalAsync(context);
			return Run(value);
		}

		public virtual object Run(object operand) {
			throw new NotSupportedException($"Unary operation '{Operator}' is not implemented.");
		}
	}
}