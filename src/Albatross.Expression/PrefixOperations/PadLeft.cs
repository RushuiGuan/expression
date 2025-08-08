using System;
using System.Collections.Generic;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.PrefixOperations {
	[ParserOperation]
	public class PadLeft : PrefixExpression {
		public const char DefaultPaddingCharacter = ' ';
		public PadLeft() : base("PadLeft", 2, 3) { }
		
		public override object Run(List<object> operands) {
			var text = operands[0].ConvertToString();
			var count = operands[1].ConvertToInt();

			char paddingCharacter;
			if (this.Operands.Count > 2) {
				paddingCharacter = operands.GetRequiredStringValue(2)[0];
			} else {
				paddingCharacter = DefaultPaddingCharacter;
			}
			return text.PadLeft(count, paddingCharacter);
		}
	}
}
