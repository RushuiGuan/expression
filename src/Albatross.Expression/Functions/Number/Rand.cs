using Albatross.Expression.Documentation;
using Albatross.Expression.Documentation.Attributes;
using Albatross.Expression.Tokens;
using System;

namespace Albatross.Expression.Functions.Number
{
    [FunctionDoc(Group.Number, "{token}()",
        @"
### Generate random value between 0.0 and 1.0
#### Inputs:
#### Outputs:
- Random number between 0.0 and 1.0.

#### References:
- [{token}](https://help.workiom.com/article/formula#{token})
        ",
        @"
{token}()
        "
    )]
    [ParserOperation]
    public class Rand : PrefixOperationToken
    {
        public override string Name { get { return "Rand"; } }
        public override int MinOperandCount { get { return 0; } }
        public override int MaxOperandCount { get { return 0; } }
        public override bool Symbolic { get { return false; } }

        public override object EvalValue(Func<string, object> context)
        {
            return new Random(DateTime.UtcNow.Second).NextDouble();
        }
    }
}
