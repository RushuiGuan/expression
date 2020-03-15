using Albatross.Expression.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Albatross.Expression.Numeric {
	public interface INumericOperation {
		object Run(object a, object b);
	}
	public abstract class NumericOperation<T> where T:struct{
		private readonly IConvertNumeric<T> convertNumeric;

		public NumericOperation(IConvertNumeric<T> convertNumeric) {
			this.convertNumeric = convertNumeric;
		}

		public object Run(object a, object b) {
			T? op1 = convertNumeric.Convert(a);
			T? op2 = convertNumeric.Convert(b);
			if (op1 == null || op2 == null) {
				return null;
			} else {
				return Calculate(op1.Value, op2.Value);
			}
		}
		protected abstract T Calculate(T a, T b);
	}
	public abstract class GenericNumericOperation<T> : NumericOperation<T> where T : struct {
		Func<T, T, T> func;
		public GenericNumericOperation(IConvertNumeric<T> convertNumeric) : base(convertNumeric) {
			func = CreateExpression();
		}
		protected override T Calculate(T a, T b) {
			return func(a, b);
		}
		public abstract Func<T, T, T> CreateExpression();
	}
}
