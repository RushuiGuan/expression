using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Albatross.Expression.Exceptions {
	public class OperandException : Exception {
		public OperandException(string operation) 
			: base(string.Format("Operation {0} doesn't have the right operand count", operation)) {
			Operation = operation;
		}
		public string Operation { get; private set; }
	}
}
