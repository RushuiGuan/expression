using Albatross.Expression.Exceptions;
using System;
using Exp = System.Linq.Expressions;

namespace Albatross.Expression.Numeric {

	public interface IMultiplyNumber {
		object Run(object a, object b);
	}

	public class MultiplyNumberDouble : NumericOperation<double>, IMultiplyNumber {
		public MultiplyNumberDouble(IConvertNumeric<double> convertNumeric) : base(convertNumeric) {
		}

		protected override double Calculate(double a, double b) {
			return a * b;
		}
	}

	public class MultiplyNumberDecimal : NumericOperation<Decimal>, IMultiplyNumber {
		public MultiplyNumberDecimal(IConvertNumeric<Decimal> convertNumeric) : base(convertNumeric) {
		}

		protected override Decimal Calculate(Decimal a, Decimal b) {
			return a * b;
		}
	}
}

