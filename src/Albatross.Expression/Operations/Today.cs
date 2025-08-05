using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Nodes;
using System.Xml;
using Albatross.Expression.Exceptions;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class Today : PrefixExpression {
		public Today() : base("Today", 0, 0) { }
		
		public override object? Eval(Func<string, object> context) {
			return DateTime.Today;
		}
	}
}
