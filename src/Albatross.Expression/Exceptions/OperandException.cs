using System;

namespace Albatross.Expression.Exceptions {
	public class OperandException : Exception {
		public OperandException(string operation) 
			: base(string.Format($"{nameof(Operation)} {{0}} doesn't have the right operand count", operation)) {
			Operation = operation;
		}
		public string Operation { get; private set; }
	}
}
