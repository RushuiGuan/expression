using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Nodes;
using System.Xml;
using Albatross.Expression.Exceptions;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class Pi : PrefixExpression {
		public Pi() : base("Pi", 0, 0) { }
		
		public override object? Eval(Func<string, object> context) {
			return Math.PI;
		}
	}
}
