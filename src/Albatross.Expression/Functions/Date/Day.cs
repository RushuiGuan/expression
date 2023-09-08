using Albatross.Expression.Documentation;
using Albatross.Expression.Documentation.Attributes;
using Albatross.Expression.Tokens;
using System;
using System.Linq;

namespace Albatross.Expression.Operations
{
    [FunctionDoc(Group.Date, "{token}( )",
@"### Returns the day of the given date as number.
#### Inputs:
- date: date
#### Outputs:
- The day value between 1 and 31."
    )]
    [ParserOperation]
    public class Day : PrefixOperationToken
    {

        public override string Name { get { return "Day"; } }
        public override int MinOperandCount { get { return 1; } }
        public override int MaxOperandCount { get { return 1; } }
        public override bool Symbolic { get { return false; } }

        public override object EvalValue(Func<string, object> context)
        {
            object a = Operands.First().EvalValue(context);
            if (a == null) { return null; }
            if (a is DateTime)
            {
                return Convert.ToDouble(((DateTime)a).Day);
            }
            else
            {
                DateTime datetime;
                if (DateTime.TryParse(Convert.ToString(a), out datetime))
                {
                    return Convert.ToDouble(datetime.Day);
                }
                else
                {
                    throw new FormatException("Invalid Datetime Format");
                }
            }
        }
    }
}
