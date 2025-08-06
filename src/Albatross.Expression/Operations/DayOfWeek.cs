using System;
using Albatross.Expression.Nodes;


namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class DayOfWeek : PrefixExpression {
		public DayOfWeek() : base("DayOfWeek", 1, 1) { }
		public override object Eval(Func<string, object> context) {
			var value = this.GetValue(0, context);
			var dateTime = value.ConvertToDateTime();
			return Convert.ToDouble(dateTime.DayOfWeek);
		}
	}
}
