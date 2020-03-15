using Albatross.Expression.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Albatross.Expression.Numeric {
	public interface IConvertNumeric<T> where T:struct{
		T? Convert(object value);
	}

	public class ConvertNumeric<T> : IConvertNumeric<T> where T : struct {
		public ConvertNumeric() {
			typeof(T).EnsureNumericType();
		}

		public T? Convert(object value) {
			if(value != null) {
				try {
					return (T)System.Convert.ChangeType(value, typeof(T));
				} catch {
					throw new UnexpectedTypeException(value.GetType());
				}
			} else {
				return null;
			}
		}
	}
}
