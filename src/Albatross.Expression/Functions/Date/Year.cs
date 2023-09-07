using Albatross.Expression.Documentation;
using Albatross.Expression.Documentation.Attributes;
using Albatross.Expression.Tokens;
using System;
using System.Linq;


namespace Albatross.Expression.Operations
{
    [FunctionDoc(Group.Date, "{token}( )",
        @"
		### Returns the year of the given date as a number.

		#### Inputs:
		- date: date

		#### Outputs:
		- The year value as number.
		"
    )]
    [ParserOperation]
    public class Year : PrefixOperationToken
    {

        public override string Name { get { return "Year"; } }
        public override int MinOperandCount { get { return 1; } }
        public override int MaxOperandCount { get { return 1; } }
        public override bool Symbolic { get { return false; } }

        public override object EvalValue(Func<string, object> context)
        {
            object value = Operands.First().EvalValue(context);
            if (value == null) { return null; }
            else if (value is DateTime time)
            {
                return Convert.ToDouble(time.Year);
            }
            else
            {
                DateTime datetime;
                if (DateTime.TryParse(Convert.ToString(value), out datetime))
                {
                    return Convert.ToDouble(datetime.Year);
                }
                else
                {
                    throw new FormatException("Invalid DateTime Format");
                }
            }
        }
    }
}
