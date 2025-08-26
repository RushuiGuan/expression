using System.Collections.Generic;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Prefix {
	public class Text : PrefixExpression {
		public Text() : base("Text", 1, 1) { }

		protected override object Run(List<object> operands) 
			=>  operands[0].ConvertToString();
	}
}
