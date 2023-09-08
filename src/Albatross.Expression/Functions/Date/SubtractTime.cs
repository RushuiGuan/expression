using Albatross.Expression.Documentation;
using Albatross.Expression.Documentation.Attributes;
using Albatross.Expression.Tokens;
using System;

namespace Albatross.Expression.Functions.Date
{
    [FunctionDoc(Group.Date, "{token}( , )",
@"### Subtacts the given date-time values to return the minutes between them.
#### Inputs:
- datetime1: datetime
- datetime2: datetime
#### Outputs:
- The total minutes between the two dates."
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

            date1 = date1.AddSeconds(-date1.Second).AddSeconds(1);
            date2 = date2.AddSeconds(-date2.Second);

            var result = (double)((long)date1.Subtract(date2).TotalMinutes);
            return result;
        }
    }
}
