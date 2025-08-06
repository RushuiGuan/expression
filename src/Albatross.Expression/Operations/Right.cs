using System;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class Right : PrefixExpression {
		public Right() : base("Right", 2, 2) { }
		
		public override object Eval(Func<string, object> context) {
			var text = this.GetStringValue(0, context);
			var count = this.GetValue(1, context).ConvertToInt();
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
