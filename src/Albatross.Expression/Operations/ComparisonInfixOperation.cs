using System;
using System.Collections.Generic;
using Albatross.Expression.Exceptions;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Operations {
	public abstract class ComparisonInfixOperation : InfixExpression {
		protected ComparisonInfixOperation(string operatorSymbol, int precedence) : base(operatorSymbol, precedence) { }

		public override object Eval(Func<string, object> context) {
			var a = RequiredLeft.Eval(context);
			var b = RequiredRight.Eval(context);
			var leftType = a.GetType();
			var rightType = b.GetType();
			if (leftType != rightType) {
				throw new OperandException($"Infix expression '{this.Operator}' has mixed types ({leftType.Name}, {rightType.Name}) between its left and right operands");
			}
			int result = 0;
			if (leftType == typeof(double)) {
				result = Comparer<double>.Default.Compare((double)a, (double)b);
			} else if (leftType == typeof(DateTime)) {
				result = Comparer<System.DateTime>.Default.Compare((System.DateTime)a, (System.DateTime)b);
			} else if (leftType == typeof(string)) {
				result = Comparer<string>.Default.Compare((String)a, (String)b);
			} else if (leftType == typeof(bool)) {
				result = Comparer<bool>.Default.Compare((bool)a, (bool)b);
			} else {
				throw new OperandException($"Infix expression '{this.Operator}' does not support comparison for type {leftType.Name}");
			}
			return Interpret(result);
		}

		public abstract bool Interpret(int comparisonResult);
	}
}