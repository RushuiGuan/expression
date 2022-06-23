using Albatross.Expression.Tokens;
using System;
using Albatross.Expression.Documentation;
using Albatross.Expression.Documentation.Attributes;

namespace Albatross.Expression.Functions.Date
{
	[FunctionDoc(Group.Date, "{token}(@datetime1,@datetime2)",
		@"
### Subtacts the given date-time values to return the minutes between them.

#### Inputs:
- datetime1: datetime
- datetime2: datetime

#### Outputs:
- The total minutes between the two dates.

#### References:
- [{token}](https://help.workiom.com/article/formula#{token})
        ",
		@"
{token}(2021-12-31 11:15:00, 2021-12-31 10:15:00)
        "
	)]
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

			var result = (long)date1.Subtract(date2).TotalMinutes;
			return result;
		}
	}
}
