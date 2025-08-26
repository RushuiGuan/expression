using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Prefix {
	/// <summary>
	/// Return the value of a json array item based on the provided index
	/// </summary>
	public class ArrayItem : PrefixExpression {
		public ArrayItem() : base("ArrayItem", 2, 2) { }

		public override object Run(List<object> operands) {
			var values = operands[0];
			var	index = operands[1].ConvertToInt();
			if (values is List<object> list) {
				if (index >= list.Count) {
					throw new ArgumentException($"Index {index} is out of bound for the array of {list.Count} elements");
				} else {
					return list[index];
				}
			} else if (values is JsonElement element && element.ValueKind == JsonValueKind.Array) {
				var length = element.GetArrayLength();
				if (index >= length) {
					throw new ArgumentException($"Index {index} is out of bound for the json array of {length} elements");
				} else {
					return element[index].GetJsonValue() ?? string.Empty;
				}
			} else if (values is IEnumerable items) {
				int count = 0;
				foreach (var item in items) {
					if (index == count) {
						return item;
					}
					count++;
				}
				throw new ArgumentException($"Index {index} is out of bound for the collection of {count} elements");
			}
			throw new ArgumentException($"{values} is not a collection");
		}
	}
}
