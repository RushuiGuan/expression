using Albatross.Expression.Exceptions;
using System;
using Exp = System.Linq.Expressions;

namespace Albatross.Expression.Numeric {
	public interface IAddNumber : INumericOperation { }

	public class AddNumberDouble : NumericOperation<double>, IAddNumber {
		public AddNumberDouble(IConvertNumeric<double> convertNumeric) : base(convertNumeric) { }
		protected override double Calculate(double a, double b) => a + b;
	}

	public class AddNumberDecimal : NumericOperation<decimal>, IAddNumber {
		public AddNumberDecimal(IConvertNumeric<decimal> convertNumeric) : base(convertNumeric) { }
		protected override decimal Calculate(decimal a, decimal b) => a + b;
	}

	public class AddNumber<T> : GenericNumericOperation<T>, IAddNumber where T : struct {
		public AddNumber(IConvertNumeric<T> convertNumeric) : base(convertNumeric) { }
		public override Func<T, T, T> CreateExpression() {
			var paramA = Exp.Expression.Parameter(typeof(T), "a");
			var paramB = Exp.Expression.Parameter(typeof(T), "b");
			Exp.BinaryExpression body = Exp.Expression.Add(paramA, paramB);
			return Exp.Expression.Lambda<Func<T, T, T>>(body, paramA, paramB).Compile();
		}
	}
}