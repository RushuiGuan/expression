using System;
using System.Collections.Generic;
using Albatross.Expression.Exceptions;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.InfixOperations {
	public abstract class ComparisonInfixOperation : InfixExpression {
		protected ComparisonInfixOperation(string operatorSymbol, int precedence) : base(operatorSymbol, precedence) { }

		public abstract bool Interpret(int comparisonResult);

		public override object Run(object left, object right) {
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