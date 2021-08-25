using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using System.Xml;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class Negative : PrefixOperationToken {
		
		public override string Name { get { return "-"; } }
		public override int MinOperandCount { get { return 1; } }
		public override int MaxOperandCount { get { return 1; } }
		public override bool Symbolic { get { return true; } }

		public override object EvalValue(Func<string, object> context) {
			object a = GetOperands(context).First();

			if (a is double){
				return (double)a * -1;
			}
			throw new FormatException();
		}
	}
}
