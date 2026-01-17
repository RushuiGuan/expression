using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Exceptions;
using Albatross.Expression.Parsing;
using Albatross.Expression.Nodes;
using System.Threading.Tasks;

namespace Albatross.Expression.Prefix {
	/// <summary>
	/// Base implementation for prefix function expressions that operate on multiple operands.
	/// </summary>
	public class PrefixExpression : IPrefixExpression {
		/// <summary>
		/// Initializes a new instance of the <see cref="PrefixExpression"/> class.
		/// </summary>
		/// <param name="name">The name of the prefix function.</param>
		/// <param name="minOperandCount">The minimum number of operands required.</param>
		/// <param name="maxOperandCount">The maximum number of operands accepted.</param>
		public PrefixExpression(string name, int minOperandCount, int maxOperandCount) {
			Name = name;
			MinOperandCount = minOperandCount;
			MaxOperandCount = maxOperandCount;
		}

		/// <summary>
		/// The name of the prefix function.
		/// </summary>
		public string Name { get; }
		
		/// <summary>
		/// The token representation, which is the same as the Name.
		/// </summary>
		public string Token => Name;
		
		/// <summary>
		/// The minimum number of operands this function requires.
		/// </summary>
		public int MinOperandCount { get; }
		
		/// <summary>
		/// The maximum number of operands this function accepts.
		/// </summary>
		public int MaxOperandCount { get; }

		/// <summary>
		/// The list of operand expressions passed to this function.
		/// </summary>
		public IReadOnlyList<IExpression> Operands { get; set; } = [];

		/// <inheritdoc />
		public string Text() {
			var sb = new StringBuilder();
			sb.Append(Name);
			sb.Append(ControlTokenFactory.LeftParenthesis.Token);
			foreach (var token in Operands) {
				sb.Append(token.Text());
				if (token != Operands.Last()) {
					sb.Append(ControlTokenFactory.Comma.ToString()).Append(' ');
				}
			}
			sb.Append(ControlTokenFactory.RightParenthesis.Token);
			return sb.ToString();
		}

		/// <inheritdoc />
		public object Eval(Func<string, object> context) {
			ValidateOperands();
			var values = this.GetValues(context);
			return Run(values);
		}

		/// <inheritdoc />
		public async Task<object> EvalAsync(Func<string, Task<object>> context) {
			ValidateOperands();
			var values = await this.GetValuesAsync(context);
			return Run(values);
		}

		/// <summary>
		/// Executes the prefix function with the evaluated operand values.
		/// Derived classes should override this method to implement specific function logic.
		/// </summary>
		/// <param name="operands">The list of evaluated operand values.</param>
		/// <returns>The result of the function.</returns>
		protected virtual object Run(List<object> operands) {
			throw new NotSupportedException($"Prefix expression {this.Name} is not supported");
		}

		/// <summary>
		/// Validates that the number of operands is within the allowed range.
		/// </summary>
		/// <exception cref="OperandException">Thrown when the operand count is outside the valid range.</exception>
		protected void ValidateOperands() {
			if (Operands.Count < MinOperandCount) {
				throw new OperandException($"Prefix operation '{Name}' requires at least {MinOperandCount} operands, but received {Operands.Count}.");
			}
			if (Operands.Count > MaxOperandCount) {
				throw new OperandException($"Prefix operation '{Name}' allows at most {MaxOperandCount} operands, but received {Operands.Count}.");
			}
		}
	}
}