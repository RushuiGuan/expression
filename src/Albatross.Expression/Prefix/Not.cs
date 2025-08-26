using System.Collections.Generic;

namespace Albatross.Expression.Prefix {
	public class Not : PrefixExpression {
		public Not() : base("Not", 1, 1) { }
		
		protected override object Run(List<object> operands) {
			return !operands[0].ConvertToBoolean();
		}
	}
}
