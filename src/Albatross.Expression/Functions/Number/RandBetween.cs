using Albatross.Expression.Documentation;
using Albatross.Expression.Documentation.Attributes;
using Albatross.Expression.Tokens;
using System;
using System.Linq;

namespace Albatross.Expression.Functions.Number
{
    [FunctionDoc(Group.Number, "{token}( , )",
        @"
        ### Generate random value
        #### Inputs:
        - @val1: Max value, or minimum value of a range (optional)
        - @val2: Maximum value of the range (optional)
        #### Outputs:
        - Non negative random integer.
        "
    )]
    [ParserOperation]
    public class RandBetween : PrefixOperationToken
    {
        public override string Name { get { return "RandBetween"; } }
        public override int MinOperandCount { get { return 0; } }
        public override int MaxOperandCount { get { return 2; } }
        public override bool Symbolic { get { return false; } }

        public override object EvalValue(Func<string, object> context)
        {
            var rand = new Random(Guid.NewGuid().GetHashCode());
            var input = Operands.Select(item => (int)Convert.ChangeType(item.EvalValue(context), typeof(int))).ToArray();

            if (input.Length == 1)
                return (double)rand.Next(input[0]);
            else if (input.Length == 2)
                return (double)rand.Next(input[0], input[1]);

            return (double)rand.Next();
        }
    }
}
