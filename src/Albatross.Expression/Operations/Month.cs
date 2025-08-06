using System;
using Albatross.Expression.Nodes;


namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class Month : PrefixExpression {
		public Month() : base("Month", 1, 1) { }

		public override object Eval(Func<string, object> context) {
			var dateTime = this.GetValue(0, context).ConvertToDateTime();
			return dateTime.Month;			
		}
	}
}
