﻿using System;
using System.Linq;
using System.Text.Json;
using Albatross.Expression.Tokens;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class GetJsonArrayCount : PrefixOperationToken {

		public override string Name { get { return "GetJsonArrayCount"; } }
		public override int MinOperandCount { get { return 1; } }
		public override int MaxOperandCount { get { return 1; } }
		public override bool Symbolic { get { return false; } }

		public override object EvalValue(Func<string, object> context) {
			object value = GetOperands(context).First();
			JsonElement elem;
			if (value is JsonElement) {
				elem = (JsonElement)value;
			} else {
				var doc = JsonDocument.Parse(Convert.ToString(value));
				elem = doc.RootElement;
			}
			if (elem.ValueKind == JsonValueKind.Array) {
				return elem.GetArrayLength();
			} else {
				throw new InvalidOperationException("Input value is not an array");
			}
		}
	}
}
