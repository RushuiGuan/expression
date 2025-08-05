using System;
using System.Collections.Generic;
using Albatross.Expression.Nodes;
using Albatross.Expression.Exceptions;
using System.Collections;
using System.Text.Json;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class Len : PrefixExpression {
		public Len() : base("Len", 1, 1) { }

		public override object? Eval(Func<string, object> context) {
			List<object> list =  GetOperands(context);

			object value = list[0];
			if (value == null) {
				return null;
			}else  if (value is ICollection) {
				return ((ICollection)value).Count;
			}if (value is string) {
				return ((string)value).Length;
			}else if(value is JsonElement) {
				JsonElement elem = (JsonElement)value;
				return elem.GetArrayLength();
			} else {
				throw new UnexpectedTypeException(value.GetType());
			}
		}
	}
}
