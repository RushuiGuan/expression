using System;

namespace Albatross.Expression.Numeric {
	public class DivideNumberDouble : NumericOperation<double>, IDivideNumber {
		protected override double Calculate(double a, double b) {
			throw new NotImplementedException();
		}
	}
}

