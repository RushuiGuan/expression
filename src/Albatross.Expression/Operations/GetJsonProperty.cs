using System;
using Albatross.Expression.Nodes;
using Json.Pointer;

namespace Albatross.Expression.Operations {
	/// <summary>
	/// return the json property using the supplied path.  Operand 1 is the input json value, if the input is text, it will be parsed into a json element.
	/// Operand 2 and beyond are the json property path.
	/// </summary>
	[ParserOperation]
	public class GetJsonProperty : PrefixExpression {
		public GetJsonProperty() : base("JsonProperty", 2, 2) { }

		public override object Eval(Func<string, object> context) {
			var element = this.GetValue(0, context).ConvertToJsonElement();
			var pointerText = this.GetRequiredStringValue(1, context);
			var pointer = JsonPointer.Parse(pointerText);
			var result = pointer.Evaluate(element);
			if (result == null) {
				throw new ArgumentException($"Json path '{pointerText}' not found in {element}");
			}
			return result;
		}
	}
}
