using Albatross.Expression.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Albatross.Expression.Functions.Date
{
	[ParserOperation]
	public class SubtractDate : PrefixOperationToken
	{
		public override string Name { get { return "subtractDate"; } }
		public override int MinOperandCount { get { return 2; } }
		public override int MaxOperandCount { get { return 2; } }
		public override bool Symbolic { get { return false; } }

		public override object EvalValue(Func<string, object> context)
		{
			DateTime date1 = (DateTime)Convert.ChangeType(Operands[0].EvalValue(context), typeof(DateTime));
			DateTime date2 = (DateTime)Convert.ChangeType(Operands[1].EvalValue(context), typeof(DateTime));

			var result = date1.Subtract(date2).TotalDays;
			return result;
		}
	}
}
