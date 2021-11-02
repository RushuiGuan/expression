using Albatross.Expression.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using Albatross.Expression.Documentation.Attributes;
using Albatross.Expression.Documentation;

namespace Albatross.Expression.Functions.Number
{
    [FunctionDoc(Group.Number, "{token}(@val)",
        @"
### Return number value of the passed string
#### Inputs:
- @val: Number as a string
#### Outputs:
- Double.

#### References:
- [{token}](https://help.workiom.com/article/formula#{token})
        ",
        @"
{token}('1')
        "
    )]
    [ParserOperation]
    public class Number : PrefixOperationToken
    {
        public override string Name { get { return "number"; } }
        public override int MinOperandCount { get { return 1; } }
        public override int MaxOperandCount { get { return 1; } }
        public override bool Symbolic { get { return false; } }

        public override object EvalValue(Func<string, object> context)
        {
            object value = Operands.First().EvalValue(context);
            return Convert.ToDouble(value.ToString());
        }
    }
}
