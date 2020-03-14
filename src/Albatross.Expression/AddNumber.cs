using System;
using Exp = System.Linq.Expressions;

namespace Albatross.Expression {

	public interface IAddNumber<T> where T : struct {
		T Add(T a, T b);
	}


	public class AddNumber<T> : IAddNumber<T> where T : struct {
		Func<T, T, T> func;
		public AddNumber() {
			var paramA = Exp.Expression.Parameter(typeof(T), "a");
			var paramB = Exp.Expression.Parameter(typeof(T), "b");
			Exp.BinaryExpression body = Exp.Expression.Add(paramA, paramB);
			func = Exp.Expression.Lambda<Func<T, T, T>>(body, paramA, paramB).Compile();
		}

		public T Add(T a, T b) {
			return func(a, b);
		}
	}
}

