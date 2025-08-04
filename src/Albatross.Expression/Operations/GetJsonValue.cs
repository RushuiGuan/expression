using System;
using System.Linq;
using System.Text.Json;
using Albatross.Expression.Tokens;

namespace Albatross.Expression.Operations {
	/// <summary>
	/// return the json property using the supplied path.  Operand 1 is the input json value, if the input is text, it will be parsed into a json element.
	/// Operand 2 and beyond are the json property path.
	/// </summary>
	[ParserOperation]
	public class GetJsonValue : PrefixOperationToken {

		public override string Name { get { return "GetJsonValue"; } }
		public override int MinOperandCount { get { return 2; } }
		public override int MaxOperandCount { get { return int.MaxValue; } }
		public override bool Symbolic { get { return false; } }

		public override object? Eval(Func<string, object> context) {
			var operands = GetOperands(context);
			object value = operands.First();
			JsonElement elem;
			if (value is JsonElement) {
				elem = (JsonElement)value;
			} else {
				using (var doc = JsonDocument.Parse(Convert.ToString(value))) {
					elem = doc.RootElement.Clone();
				}
			}
			for (int i = 1; i < operands.Count; i++) {
				string member = Convert.ToString(operands[i]);
				if (elem.ValueKind == JsonValueKind.Object) {
					if (!elem.TryGetProperty(member, out elem)) {
						return null;
					}
				}
			}
			return elem.GetJsonValue();
		}
	}
}
