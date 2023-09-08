using Albatross.Expression.Documentation;
using Albatross.Expression.Documentation.Attributes;
using Albatross.Expression.Tokens;
using System;

namespace Albatross.Expression.Operations
{
    [FunctionDoc(Group.Number, "{token}()",
@"### Return PI value
#### Inputs:
- No inputs
#### Outputs:
- Double."
    )]
    [ParserOperation]
    public class Pi : PrefixOperationToken
    {

        public override string Name { get { return "pi"; } }
        public override int MinOperandCount { get { return 0; } }
        public override int MaxOperandCount { get { return 0; } }
        public override bool Symbolic { get { return false; } }

        public override object EvalValue(Func<string, object> context)
        {
            return Math.PI;
        }
    }
}
