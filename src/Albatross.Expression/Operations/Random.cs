using System;
using Albatross.Expression.Tokens;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class Random : PrefixOperationToken {

		public override string Name { get { return "random"; } }
		public override int MinOperandCount { get { return 2; } }
		public override int MaxOperandCount { get { return 2; } }
		public override bool Symbolic { get { return false; } }


		public override object? Eval(Func<string, object> context) {
			var operands = GetOperands(context);
			int min = Convert.ToInt32(operands[0]);
			int max = Convert.ToInt32(operands[1]);
			return new System.Random().Next(min, max);
		}
	}
}
