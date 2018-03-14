using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Albatross.Expression.Exceptions {
	public class UnexpectedTypeException : Exception {
		public UnexpectedTypeException() { }
		public UnexpectedTypeException(string msg) : base(msg) { }
		public UnexpectedTypeException(Type type):base(string.Format("Type {0} is not expected!", type.Name)) {
		}
		public UnexpectedTypeException(Type type1, Type type2)
			: base(string.Format("Different types encountered within the same operation: {0}, {1}", type1.Name, type2.Name)) {
		}
	}
}
