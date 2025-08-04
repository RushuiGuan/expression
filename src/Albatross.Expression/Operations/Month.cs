using System;
using System.Linq;
using Albatross.Expression.Nodes;


namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class Month : PrefixExpression {

		public override string Name { get { return "Month"; } }
		public override int MinOperandCount { get { return 1; } }
		public override int MaxOperandCount { get { return 1; } }
		public override bool Symbolic { get { return false; } }

		public override object? Eval(Func<string, object> context) {
			object a = GetOperands(context).First();
			if (a == null) { return null; }
			if (a is DateTime) {
				return Convert.ToDouble(((DateTime)a).Month);
			} else {
				DateTime datetime;
				if (DateTime.TryParse(Convert.ToString(a), out datetime)) {
					return Convert.ToDouble(datetime.Month);
				} else {
					throw new FormatException("Invalid Datetime Format");
				}
			}
		}
	}
}
