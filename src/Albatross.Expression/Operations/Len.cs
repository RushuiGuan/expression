using Albatross.Expression.Nodes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class Len : PrefixExpression {
		public Len() : base("Len", 1, 1) { }

		public override object Run(List<object> operands) {
			var value = operands[0];
			if (value is ICollection collection) {
				return collection.Count;
			}
			if (value is string text) {
				return text.Length;
			} else if (value is JsonElement json && json.ValueKind == JsonValueKind.Array) {
				return json.GetArrayLength();
			} else {
				throw new FormatException($"{value} is not a collection, string or json array");
			}
		}
	}
}
