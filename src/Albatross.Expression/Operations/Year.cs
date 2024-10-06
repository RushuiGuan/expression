using System;
using System.Linq;
using Albatross.Expression.Tokens;


namespace Albatross.Expression.Operations {
	[ParserOperation]
	public class Year : PrefixOperationToken {

		public override string Name { get { return "Year"; } }
		public override int MinOperandCount { get { return 1; } }
		public override int MaxOperandCount { get { return 1; } }
		public override bool Symbolic { get { return false; } }

		public override object? EvalValue(Func<string, object> context) {
			var value = GetOperands(context).First();
			if (value == null) { return null; }
			else if (value is DateTime) {
				return Convert.ToDouble(((DateTime)value).Year);
			} else {
				DateTime datetime;
				if (DateTime.TryParse(Convert.ToString(value), out datetime)) {
					return Convert.ToDouble(datetime.Year);
				} else {
					throw new FormatException("Invalid DateTime Format");
				}
			}
		}
	}
}
