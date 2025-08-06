using System;
using Albatross.Expression.Nodes;


namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class Year : PrefixExpression {
		public Year() : base("Year", 1, 1) { }

		public override object Eval(Func<string, object> context)
			=> Convert.ToDouble(this.GetValue(0, context).ConvertToDateTime().Year);
	}
}
