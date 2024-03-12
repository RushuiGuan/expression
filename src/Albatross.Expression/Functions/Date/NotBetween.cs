using System;
using Albatross.Expression.Documentation;
using Albatross.Expression.Documentation.Attributes;
using Albatross.Expression.Tokens;

namespace Albatross.Expression.Functions.Date
{
    [FunctionDoc(Group.Date, "{token}( , )",
        @"### Check if the given date is between a range of dates.
#### Inputs:
- date: date
- dateGreater: date
- dateLesser: date
#### Outputs:
- True/False")]
    [ParserOperation]
    public class NotBetween : PrefixOperationToken
    {
        public override string Name => "NotBetween";
        public override int MinOperandCount => 3;
        public override int MaxOperandCount => 3;
        public override bool Symbolic => false;

        public override object EvalValue(Func<string, object> context)
        {
            var date = (DateTime)Convert.ChangeType(Operands[0].EvalValue(context), typeof(DateTime));
            var dateGreater = (DateTime)Convert.ChangeType(Operands[1].EvalValue(context), typeof(DateTime));
            var dateLesser = (DateTime)Convert.ChangeType(Operands[2].EvalValue(context), typeof(DateTime));

            return (date < dateLesser) || (date > dateGreater);        
        }
    }
}