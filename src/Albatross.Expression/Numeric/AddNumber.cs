using Albatross.Expression.Exceptions;
using System;
using Exp = System.Linq.Expressions;

namespace Albatross.Expression.Numeric {

	public interface IAddNumber : INumericOperation {
	}


	public class AddNumberDouble : NumericOperation<double>, IAddNumber {
		public AddNumberDouble(IConvertNumeric<double> convertNumeric) : base(convertNumeric) {
		}

		protected override double Calculate(double a, double b) {
			return a + b;
		}
	}
	public class AddNumberDecimal: NumericOperation<decimal>, IAddNumber {
		public AddNumberDecimal(IConvertNumeric<decimal> convertNumeric) : base(convertNumeric) {
		}

		protected override decimal Calculate(decimal a, decimal b) {
			return a + b;
		}
	}
}

