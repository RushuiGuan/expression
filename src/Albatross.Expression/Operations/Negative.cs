using System;
using System.Linq;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class Negative : PrefixExpression {
		
		public override string Name { get { return "-"; } }
		public override int MinOperandCount { get { return 1; } }
		public override int MaxOperandCount { get { return 1; } }
		public override bool Symbolic { get { return true; } }

		public override object? Eval(Func<string, object> context) {
			object a = GetOperands(context).First();

			if (a is double){
				return (double)a * -1;
			}
			throw new FormatException();
		}
	}
}
