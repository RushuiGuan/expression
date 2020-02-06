using Albatross.Expression.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Albatross.Expression.Functions.Number
{
    [ParserOperation]
    public class ToNumber : PrefixOperationToken
    {
        public override string Name { get { return "toNumber"; } }
        public override int MinOperandCount { get { return 1; } }
        public override int MaxOperandCount { get { return 1; } }
        public override bool Symbolic { get { return false; } }

        public override object EvalValue(Func<string, object> context)
        {
            object value = Operands.First().EvalValue(context);
            if (value is string)
            {
                return Convert.ToDouble(value.ToString());
            }
            else
            {
                return DateTime.Parse(Convert.ToString(value));
            }
        }
    }
}
