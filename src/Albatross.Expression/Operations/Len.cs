using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using System.Xml;
using Albatross.Expression.Exceptions;
using System.Collections;
using System.Text.Json;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class Len : PrefixOperationToken {

		public override string Name { get { return "len"; } }
		public override int MinOperandCount { get { return 1; } }
		public override int MaxOperandCount { get { return 1; } }
		public override bool Symbolic { get { return false; } }

		public override object EvalValue(Func<string, object> context) {
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
