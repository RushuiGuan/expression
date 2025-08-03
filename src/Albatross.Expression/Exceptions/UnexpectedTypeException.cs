using System;

namespace Albatross.Expression.Exceptions {
	public class UnexpectedTypeException : Exception {
		public UnexpectedTypeException() { }
		public UnexpectedTypeException(string msg) : base(msg) { }
		public UnexpectedTypeException(Type type):base($"Type {type.Name} is not expected!") {
		}
		public UnexpectedTypeException(Type type1, Type type2)
			: base($"Different types encountered within the same operation: {type1.Name}, {type2.Name}") {
		}
	}
}
