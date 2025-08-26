using System;
using System.Collections.Generic;
using Albatross.Expression.Exceptions;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Infix {
	/// <summary>
	/// Base class for infix operations that perform comparison between two operands of the same type.
	/// </summary>
	public abstract class ComparisonInfixOperation : InfixExpression {
		/// <summary>
		/// Initializes a new instance of the <see cref="ComparisonInfixOperation"/> class.
		/// </summary>
		/// <param name="operatorSymbol">The operator symbol for this comparison.</param>
		/// <param name="precedence">The precedence level for this operation.</param>
		protected ComparisonInfixOperation(string operatorSymbol, int precedence) : base(operatorSymbol, precedence) { }

		/// <summary>
		/// Interprets the result of the comparison operation.
		/// </summary>
		/// <param name="comparisonResult">The result from the comparison (-1, 0, or 1).</param>
		/// <returns>True if the comparison satisfies the operation's condition; otherwise, false.</returns>
		public abstract bool Interpret(int comparisonResult);

		protected override object Run(object left, object right) {
			var leftType = left.GetType();
			var rightType = right.GetType();
			if (leftType != rightType) {
				throw new OperandException($"Infix expression '{this.Operator}' has mixed types ({leftType.Name}, {rightType.Name}) between its left and right operands");
			}
			int result;
			if (leftType == typeof(double)) {
				result = Comparer<double>.Default.Compare((double)left, (double)right);
			} else if (leftType == typeof(DateTime)) {
				result = Comparer<System.DateTime>.Default.Compare((System.DateTime)left, (System.DateTime)right);
			} else if (leftType == typeof(string)) {
				result = Comparer<string>.Default.Compare((String)left, (String)right);
			} else if (leftType == typeof(bool)) {
				result = Comparer<bool>.Default.Compare((bool)left, (bool)right);
			} else {
				throw new OperandException($"Infix expression '{this.Operator}' does not support comparison for type {leftType.Name}");
			}
			return Interpret(result);
		}
	}
}