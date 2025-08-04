using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Nodes;
using System.Xml;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class Not : PrefixExpression {
		public override string Name { get { return "not"; } }
		public override int MinOperandCount { get { return 1; } }
		public override int MaxOperandCount { get { return 1; } }
		public override bool Symbolic { get { return false; } }

		public override object? Eval(Func<string, object> context) {
			object value = GetOperands(context).First();
			return !value.ConvertToBoolean();
		}
	}
}
