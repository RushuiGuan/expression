using Albatross.Expression.Nodes;
using System.Collections.Generic;


namespace Albatross.Expression.PrefixOperations {
	public class Year : PrefixExpression {
		public Year() : base("Year", 1, 1) { }

		public override object Run(List<object> operands) 
			=> operands[0].ConvertToDateTime().Year;
	}
}
