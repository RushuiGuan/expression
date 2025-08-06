using System;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class PadRight : PrefixExpression {
		public const char DefaultPaddingCharacter = ' ';
		public PadRight() : base("PadRight", 2, 3) { }
		
		public override object Eval(Func<string, object> context) {
			var text = this.GetStringValue(0, context);
			var count = this.GetValue(1, context).ConvertToInt();
			char paddingCharacter;
			if (this.Operands.Count > 2) {
				paddingCharacter = this.GetRequiredStringValue(2, context)[0];
			} else {
				paddingCharacter = DefaultPaddingCharacter;
			}
			return text.PadRight(count, paddingCharacter);
		}
	}
}
