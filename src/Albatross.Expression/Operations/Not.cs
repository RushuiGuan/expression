using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Nodes;
using System.Xml;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class Not : PrefixExpression {
		public Not() : base("Not", 1, 1) { }
		
		public override object? Eval(Func<string, object> context) {
			object value = GetOperands(context).First();
			return !value.ConvertToBoolean();
		}
	}
}
