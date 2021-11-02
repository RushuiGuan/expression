using Albatross.Expression.Exceptions;
using Albatross.Expression.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using Albatross.Expression.Documentation.Attributes;
using Albatross.Expression.Documentation;

namespace Albatross.Expression.Functions.Number
{
    [FunctionDoc(Group.Number, "{token}(@number)",
        @"
### Returns larget integer less than or equal the decimal number.
#### Inputs:
- number: The decimal number to round.

#### Outputs:
- Integer.

#### References:
- [{token}](https://help.workiom.com/article/formula#{token})
        ",
        @"
{token}(4.23)
        "
    )]
    [ParserOperation]
    public class RoundDown : PrefixOperationToken
    {
        public override string Name { get { return "roundDown"; } }
        public override int MinOperandCount { get { return 1; } }
        public override int MaxOperandCount { get { return 1; } }
        public override bool Symbolic { get { return false; } }

        public override object EvalValue(Func<string, object> context)
        {
            var input = Operands.Select(item => (decimal)Convert.ChangeType(item.EvalValue(context), typeof(decimal))).ToArray();

            if (input.Length == 1)
                return Math.Floor(input[0]);

            throw new UnexpectedTypeException();
        }
    }
}
