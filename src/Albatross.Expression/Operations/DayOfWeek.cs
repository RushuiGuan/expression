using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using System.Xml;
using Albatross.Expression.Exceptions;


namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class DayOfWeek : PrefixOperationToken {

		public override string Name { get { return "DayOfWeek"; } }
		public override int MinOperandCount { get { return 1; } }
		public override int MaxOperandCount { get { return 1; } }
		public override bool Symbolic { get { return false; } }

		public override object EvalValue(Func<string, object> context) {
			object a = GetOperands(context).First();
			if (a == null) { return null; }
			if (a is DateTime) {
				return Convert.ToDouble(((DateTime)a).DayOfWeek);
			} else {
				DateTime datetime;
				if (DateTime.TryParse(Convert.ToString(a), out datetime)) {
					return Convert.ToDouble(datetime.DayOfWeek);
				} else {
					throw new FormatException("Invalid Datetime Format");
				}
			}
		}
	}
}
