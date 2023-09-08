using Albatross.Expression.Documentation;
using Albatross.Expression.Documentation.Attributes;
using Albatross.Expression.Exceptions;
using Albatross.Expression.Tokens;
using System;
using System.Linq;

namespace Albatross.Expression.Functions.Number
{
    [FunctionDoc(Group.Number, "{token}( , )",
@"### Returns the Round of decimal numbers with specified number of digits.
#### Inputs:
- number: The number to round.
- digits: How many digits after decimal point.
#### Outputs:
- Decimal number after round."
    )]
    [ParserOperation]
    public class Round : PrefixOperationToken
    {
        public override string Name { get { return "Round"; } }
        public override int MinOperandCount { get { return 1; } }
        public override int MaxOperandCount { get { return 2; } }
        public override bool Symbolic { get { return false; } }

        public override object EvalValue(Func<string, object> context)
        {
            var input = Operands.Select(item => (decimal)Convert.ChangeType(item.EvalValue(context), typeof(decimal))).ToArray();

            if (input.Length == 1)
                return Math.Round(input[0]);

            if (input.Length == 2)
                return Math.Round(input[0], (int)input[1]);

            throw new UnexpectedTypeException();
        }
    }
}
