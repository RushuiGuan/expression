using System;
using System.Linq;
using System.Text.Json;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Operations {
	/// <summary>
	/// Return the length of a json array
	/// </summary>
	[ParserOperation]
	public class GetJsonArrayCount : PrefixExpression {
		public GetJsonArrayCount() : base("GetJsonArrayCount", 1, 1) { }

		public override object? Eval(Func<string, object> context) {
			object value = GetOperands(context).First();
			JsonElement elem;
			if (value is JsonElement) {
				elem = (JsonElement)value;
			} else {
				using (var doc = JsonDocument.Parse(Convert.ToString(value))) {
					elem = doc.RootElement.Clone();
				}
			}
			if (elem.ValueKind == JsonValueKind.Array) {
				return Convert.ToDouble(elem.GetArrayLength());
			} else {
				throw new InvalidOperationException("Input value is not an array");
			}
		}
	}
}
