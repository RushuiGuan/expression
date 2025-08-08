using Albatross.Expression.Nodes;
using System.Collections.Generic;

namespace Albatross.Expression.PrefixOperations {
	/// <summary>
	/// Convert a dateTime object to utc.  If the input operand is a string, the function will attempt to parse it first.
	/// </summary>
	[ParserOperation]
	public class Utc : PrefixExpression {
		public Utc() : base("Utc", 1, 1) { }

		public override object Run(List<object> operands)
			=> operands[0].ConvertToDateTime().ToUniversalTime();
	}
}