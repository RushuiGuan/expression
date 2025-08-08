using System.Collections.Generic;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class Lower : PrefixExpression {
		public Lower() : base("Lower", 1, 1) { }

		public override object Run(List<object> operands)
			=> operands[0].ConvertToString().ToLowerInvariant();
	}
}