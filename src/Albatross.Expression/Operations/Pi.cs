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
		
		public override string Name { get { return "pi"; } }
		public override int MinOperandCount { get { return 0; } }
		public override int MaxOperandCount { get { return 0; } }
		public override bool Symbolic { get { return false; } }

		public override object? Eval(Func<string, object> context) {
			return Math.PI;
		}
	}
}
