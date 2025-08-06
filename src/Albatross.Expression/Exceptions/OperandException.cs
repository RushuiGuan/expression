using System;

namespace Albatross.Expression.Exceptions {
	public class OperandException : Exception {
		public OperandException(string msg) : base(msg) { }
	}
}
