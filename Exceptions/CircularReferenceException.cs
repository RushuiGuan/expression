using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albatross.Expression.Exceptions {
	public class CircularReferenceException : Exception {
		public CircularReferenceException(string from, string to) : base(string.Format("Circular Reference from {0} to {1}", from, to)) { }
	}
}
