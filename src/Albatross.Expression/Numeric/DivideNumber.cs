namespace Albatross.Expression.Numeric {
	public interface IDivideNumber {
		object Run(object a, object b);
	}

	public class DivideNumberDouble : NumericOperation<double>, IDivideNumber {
		public DivideNumberDouble(IConvertNumeric<double> convertNumeric) : base(convertNumeric) { }
		protected override double Calculate(double a, double b) => a / b;
	}

	public class DivideNumerDecimal : NumericOperation<decimal>, IDivideNumber {
		public DivideNumerDecimal(IConvertNumeric<decimal> convertNumeric) : base(convertNumeric) { }
		protected override decimal Calculate(decimal a, decimal b) => a / b;
	}
}