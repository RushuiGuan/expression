using System;
using System.Collections.Generic;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Operations {
	public abstract class ComparisonInfixOperation : InfixExpression {
		protected ComparisonInfixOperation(string operatorSymbol, int precedence) : base(operatorSymbol, precedence) { }

		public override object Eval(Func<string, object> context) {
			var a = Left.Eval(context);
			var b = Right.Eval(context);
			Type type = a.GetType();
			if (type != b.GetType()) {
				throw new Exceptions.UnexpectedTypeException(type, b.GetType());
			}
			int result = 0;
			if (type == typeof(double)) {
				result = Comparer<double>.Default.Compare((double)a, (double)b);
			} else if (type == typeof(System.DateTime)) {
				result = Comparer<System.DateTime>.Default.Compare((System.DateTime)a, (System.DateTime)b);
			} else if (type == typeof(String)) {
				result = Comparer<string>.Default.Compare((String)a, (String)b);
			} else if (type == typeof(bool)) {
				result = Comparer<bool>.Default.Compare((bool)a, (bool)b);
			} else {
				throw new NotSupportedException();
			}
			return Interpret(result);
		}

		public abstract bool Interpret(int comparisonResult);
	}
}