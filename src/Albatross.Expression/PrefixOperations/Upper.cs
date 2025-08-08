using Albatross.Expression.Nodes;
using System.Collections.Generic;

namespace Albatross.Expression.PrefixOperations {
	[ParserOperation]
	public class Upper : PrefixExpression {
		public Upper() : base("Upper", 1, 1) { }

		public override object Run(List<object> operands) 
			=> operands[0].ConvertToString().ToUpperInvariant();
	}
}
