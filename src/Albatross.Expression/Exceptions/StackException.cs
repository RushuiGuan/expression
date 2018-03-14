using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Albatross.Expression.Exceptions {
	public class StackException : Exception {
		public StackException(string msg) : base(msg) { }
	}
}
