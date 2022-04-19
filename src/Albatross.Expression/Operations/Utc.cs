using System;
using System.Linq;
using Albatross.Expression.Tokens;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class Utc : PrefixOperationToken {
		public override string Name { get { return "Utc"; } }
		public override int MinOperandCount { get { return 1; } }
		public override int MaxOperandCount { get { return 1; } }
		public override bool Symbolic { get { return false; } }

		public override object EvalValue(Func<string, object> context) {
			object value = GetOperands(context).First();
			DateTime dateTime = (value as DateTime?) ?? DateTime.Parse(Convert.ToString(value));
			return dateTime.ToUniversalTime();
		}
	}
}