using Albatross.Expression.Documentation;
using Albatross.Expression.Documentation.Attributes;
using Albatross.Expression.Exceptions;
using Albatross.Expression.Tokens;
using System;
using System.Globalization;
using System.Linq;

namespace Albatross.Expression.Operations
{
    [FunctionDoc(Group.Date, "{token}( )",
        @"
		### Returns the name of the month as a text.

		#### Inputs:
		- date: date

		#### Outputs:
		- Month name.
		"
    )]
    [ParserOperation]
    public class MonthName : PrefixOperationToken
    {
        public override string Name { get { return "MonthName"; } }
        public override int MinOperandCount { get { return 1; } }
        public override int MaxOperandCount { get { return 1; } }
        public override bool Symbolic { get { return false; } }

        public override object EvalValue(Func<string, object> context)
        {
            object value = Operands.First().EvalValue(context);

            if (value == null)
            {
                return null;
            }
            else if (value is double)
            {
                return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(value));
            }
            else
            {
                throw new UnexpectedTypeException(value.GetType());
            }
        }
    }
}
