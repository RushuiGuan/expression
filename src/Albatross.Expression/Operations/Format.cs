using System;
using System.Text.Json;
using Albatross.Expression.Nodes;
using System.Collections.Generic;

namespace Albatross.Expression.Operations {
	/// <summary>
	/// <para>Prefix operation that will take an input and C# format string and produced a formatted string</para>
	/// 
	/// </summary>
	[ParserOperation]
	public class Format : PrefixExpression {
		public Format() : base("Format", 2, 2) { }
		

		public override object Run(List<object> operands) {
			var formatText = operands.GetRequiredStringValue(1);
			var value = operands[0];
			if (value is JsonElement element) {
				value = element.GetJsonValue();
			}
			string format = $"{{0:{formatText}}}";
			return string.Format(format, value);
		}
	}
}