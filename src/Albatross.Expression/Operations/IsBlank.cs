using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using System.Xml;
using Albatross.Expression.Exceptions;


namespace Albatross.Expression.Operations {
	/// <summary>
	/// Prefix operation to check if the input IsBlank
	/// Operand Type: any
	/// Null, empty string and string with only white space are considered as blank
	/// </summary>
	[ParserOperation]
	public class IsBlank : PrefixOperationToken {

		public override string Name { get { return "IsBlank"; } }
		public override int MinOperandCount { get { return 1; } }
		public override int MaxOperandCount { get { return 1; } }
		public override bool Symbolic { get { return false; } }

		public override object EvalValue(Func<string, object> context) {
			object value = GetOperands(context).First();

			if (value == null) {
				return true;
			} else if (value is string) {
				return string.IsNullOrWhiteSpace((string)value);
			} else {
				return false;
			}
		}
	}
}
