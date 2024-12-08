using System;
using System.Linq;
using System.Text.Json;
using Albatross.Expression.Tokens;

namespace Albatross.Expression.Operations {
	/// <summary>
	/// Return the value of a json array item based on the provided index
	/// </summary>
	[ParserOperation]
	public class GetJsonArrayItem : PrefixOperationToken {
		public override string Name { get { return "GetJsonArrayItem"; } }
		public override int MinOperandCount { get { return 2; } }
		public override int MaxOperandCount { get { return 2; } }
		public override bool Symbolic { get { return false; } }

		public override object? EvalValue(Func<string, object> context) {
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
			if (elem.ValueKind == JsonValueKind.Array) {
				var length = elem.GetArrayLength();
				var index = Convert.ToInt32(operands.Last());
				if(index >= length) {
					throw new ArgumentException($"Index {index} is out of bound for the json array");
				} else {
					return elem[index].GetJsonValue();
				}
			} else {
				throw new InvalidOperationException("Input value is not an array");
			}
		}
	}
}
