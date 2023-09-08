using Albatross.Expression.Documentation;
using Albatross.Expression.Documentation.Attributes;
using Albatross.Expression.Tokens;
using System;
using System.Globalization;
using System.Linq;

namespace Albatross.Expression.Operations
{
    [FunctionDoc(Group.Date, "{token}( )",
@"### Returns the shortened version of month name as a text.
#### Inputs:
- date: date
#### Outputs:
- Abbreviated month name"
    )]
    [ParserOperation]
    public class ShortMonthName : PrefixOperationToken
    {

        public override string Name { get { return "ShortMonthName"; } }
        public override int MinOperandCount { get { return 1; } }
        public override int MaxOperandCount { get { return 1; } }
        public override bool Symbolic { get { return false; } }

        public override object EvalValue(Func<string, object> context)
        {
            object value = Operands.First().EvalValue(context);

            if (value is double)
            {
                return CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(Convert.ToInt32(value));
            }
            throw new Exceptions.UnexpectedTypeException(value.GetType());
        }
    }
}
