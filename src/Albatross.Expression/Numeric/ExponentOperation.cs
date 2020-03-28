using Albatross.Expression.Exceptions;
using System;
using Exp = System.Linq.Expressions;

namespace Albatross.Expression.Numeric {
	public interface IExponentOperation : INumericOperation { }

	public class ExponentOperationDouble : NumericOperation<double>, IExponentOperation {
		public ExponentOperationDouble(IConvertNumeric<double> convertNumeric) : base(convertNumeric) { }
		protected override double Calculate(double a, double b) => Math.Pow(a, b);
	}
}