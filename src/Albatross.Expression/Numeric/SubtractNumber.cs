namespace Albatross.Expression.Numeric {
	public interface ISubtractNumber {
		object Run(object a, object b);
	}

	public class SubtractNumberDouble : NumericOperation<double>, ISubtractNumber {
		public SubtractNumberDouble(IConvertNumeric<double> convertNumeric) : base(convertNumeric) { }
		protected override double Calculate(double a, double b) => a - b;
	}

	public class SubtractNumberdecimal : NumericOperation<decimal>, ISubtractNumber {
		public SubtractNumberdecimal(IConvertNumeric<decimal> convertNumeric) : base(convertNumeric) { }
		protected override decimal Calculate(decimal a, decimal b) => a - b;
	}
}

