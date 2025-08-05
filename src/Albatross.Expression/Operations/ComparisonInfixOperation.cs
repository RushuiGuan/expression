using System;
using System.Collections.Generic;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Operations {
	public abstract class ComparisonInfixOperation : InfixExpression {
		protected ComparisonInfixOperation(string operatorSymbol, int precedence) : base(operatorSymbol, precedence) { }

		public override object? Eval(Func<string, object> context) {
			var a = Operand1.Eval(context);
			var b = Operand2.Eval(context);
			if (a == null || b == null) {
				return false;
			}
			Type type = a.GetType();
			if (type != b.GetType()) {
				throw new Exceptions.UnexpectedTypeException(type, b.GetType());
			}
			int result = 0;
			if (type == typeof(double)) {
				result = Comparer<double>.Default.Compare((double)a, (double)b);
			} else if (type == typeof(DateTime)) {
				result = Comparer<DateTime>.Default.Compare((DateTime)a, (DateTime)b);
			} else if (type == typeof(String)) {
				result = Comparer<String>.Default.Compare((String)a, (String)b);
			} else if (type == typeof(bool)) {
				result = Comparer<bool>.Default.Compare((bool)a, (bool)b);
			} else {
				throw new NotSupportedException();
			}
			return interpret(result);
		}

		public abstract bool interpret(int comparisonResult);
	}
}