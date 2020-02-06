using Albatross.Expression.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Albatross.Expression.Functions.Date
{
	[ParserOperation]
	public class SubtractTime : PrefixOperationToken
	{
		public override string Name { get { return "subtractTime"; } }
		public override int MinOperandCount { get { return 2; } }
		public override int MaxOperandCount { get { return 2; } }
		public override bool Symbolic { get { return false; } }

		public override object EvalValue(Func<string, object> context)
		{
			DateTime date1 = (DateTime)Convert.ChangeType(Operands[0].EvalValue(context), typeof(DateTime));
			DateTime date2 = (DateTime)Convert.ChangeType(Operands[1].EvalValue(context), typeof(DateTime));

			var result = date2.Subtract(date1).TotalMinutes;
			return result;
		}
	}
}
