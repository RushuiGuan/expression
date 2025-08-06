using System;
using Albatross.Expression.Nodes;


namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class DayOfWeek : PrefixExpression {
		public DayOfWeek() : base("DayOfWeek", 1, 1) { }
		public override object Eval(Func<string, object> context) {
			var dateTime = this.GetValue(0, context).ConvertToDateTime();
			return Convert.ToDouble(dateTime.DayOfWeek);
		}
	}
}
