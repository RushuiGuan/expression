using System.Collections.Generic;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.PrefixOperations {
	public class Not : PrefixExpression {
		public Not() : base("Not", 1, 1) { }
		
		public override object Run(List<object> operands) {
			return !operands[0].ConvertToBoolean();
		}
	}
}
