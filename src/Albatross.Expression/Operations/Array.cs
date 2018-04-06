using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using System.Xml;
using Albatross.Expression.Exceptions;


namespace Albatross.Expression.Operations {
	/// <summary>
	/// Prefix operation that create an object array
	/// Operand Count: 0 to infinite
	/// Operand Type: Any
	/// Output Type: <see cref="System.Collections.Generic.List{T}"/> where T is Object
	/// Usage: @(1, 2, 3, 4, 5)
	/// </summary>
	[ParserOperation]
	public class Array : PrefixOperationToken {
		public override string Name { get { return "@"; } }
		public override int MinOperandCount { get { return 0; } }
		public override int MaxOperandCount { get { return int.MaxValue; } }
		public override bool Symbolic { get { return false; } }

		public override object EvalValue(Func<string, object> context) {
			return GetOperands(context);
		}
	}
}
