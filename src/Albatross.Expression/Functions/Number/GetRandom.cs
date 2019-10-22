using Albatross.Expression.Tokens;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Albatross.Expression.Functions.Number
{
    [ParserOperation]
    public class GetRandom : PrefixOperationToken
    {
        public override string Name { get { return "GetRandom"; } }
        public override int MinOperandCount { get { return 0; } }
        public override int MaxOperandCount { get { return 2; } }
        public override bool Symbolic { get { return false; } }

        public override object EvalValue(Func<string, object> context)
        {
            var input = Operands.Select(item => (int)Convert.ChangeType(item.EvalValue(context), typeof(int))).ToArray();

            if (input.Length == 1)
                return new Random().Next(input[0]);
            else if (input.Length == 2)
                return new Random().Next(input[0], input[1]);

            return new Random().Next();
        }
    }
}
