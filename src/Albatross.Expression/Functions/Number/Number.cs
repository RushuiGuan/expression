using Albatross.Expression.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Albatross.Expression.Functions.Number
{
    [ParserOperation]
    public class Number : PrefixOperationToken
    {
        public override string Name { get { return "number"; } }
        public override int MinOperandCount { get { return 1; } }
        public override int MaxOperandCount { get { return 1; } }
        public override bool Symbolic { get { return false; } }

        public override object EvalValue(Func<string, object> context)
        {
            if (ExpressionMode.IsValidationMode)
                return 1D;

            object value = Operands.First().EvalValue(context);
            return Convert.ToDouble(value.ToString());
        }
    }
}
