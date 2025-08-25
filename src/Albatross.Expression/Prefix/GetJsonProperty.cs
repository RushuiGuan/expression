using System;
using System.Collections.Generic;
using Albatross.Expression.Nodes;
using Json.Pointer;

namespace Albatross.Expression.Prefix {
	/// <summary>
	/// return the json property using the supplied path.  Operand 1 is the input json value, if the input is text, it will be parsed into a json element.
	/// Operand 2 and beyond are the json property path.
	/// </summary>
	public class GetJsonProperty : PrefixExpression {
		public GetJsonProperty() : base("JsonProperty", 2, 2) { }

		public override object Run(List<object> operands) {
			var element = operands[0].ConvertToJsonElement();
			var pointerText = operands.GetRequiredStringValue(1);
			var pointer = JsonPointer.Parse(pointerText);
			var result = pointer.Evaluate(element);
			if (result == null) {
				throw new ArgumentException($"Json path '{pointerText}' not found in {element}");
			}
			return result;
		}
	}
}
