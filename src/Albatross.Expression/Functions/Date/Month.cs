using Albatross.Expression.Documentation;
using Albatross.Expression.Documentation.Attributes;
using Albatross.Expression.Tokens;
using System;
using System.Linq;


namespace Albatross.Expression.Operations
{
    [FunctionDoc(Group.Date, "{token}( )",
@"### Returns the month of the given date as a number.
#### Inputs:
- date: date
#### Outputs:
- The month value between 1 and 12."
    )]
    [ParserOperation]
    public class Month : PrefixOperationToken
    {

        public override string Name { get { return "Month"; } }
        public override int MinOperandCount { get { return 1; } }
        public override int MaxOperandCount { get { return 1; } }
        public override bool Symbolic { get { return false; } }

        public override object EvalValue(Func<string, object> context)
        {
            object a = Operands.First().EvalValue(context);
            if (a == null) { return null; }
            if (a is DateTime)
            {
                return Convert.ToDouble(((DateTime)a).Month);
            }
            else
            {
                DateTime datetime;
                if (DateTime.TryParse(Convert.ToString(a), out datetime))
                {
                    return Convert.ToDouble(datetime.Month);
                }
                else
                {
                    throw new FormatException("Invalid Datetime Format");
                }
            }
        }
    }
}
