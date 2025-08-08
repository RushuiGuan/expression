using System;
using System.Collections.Generic;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.PrefixOperations {
	[ParserOperation]
	public class Right : PrefixExpression {
		public Right() : base("Right", 2, 2) { }
		
		public override object Run(List<object> operands) {
			var text = operands[0].ConvertToString();
			var count = operands[1].ConvertToInt();
			if (count < 0) {
				throw new Exceptions.OperandException("Right operation expects a positive number for the second parameter");
			}
			if (count > text.Length) {
				return text;
			} else {
				return text.Substring(text.Length - count, count);
			}
		}
	}
}
