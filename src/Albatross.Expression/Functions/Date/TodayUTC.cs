using Albatross.Expression.Documentation;
using Albatross.Expression.Documentation.Attributes;
using Albatross.Expression.Tokens;
using System;

namespace Albatross.Expression.Operations
{
    [FunctionDoc(Group.Date, "{token}()",
        @"
### Create date object represent current date

#### Inputs:
- No inputs

#### Outputs:
- Date.

#### References:
- [{token}](https://help.workiom.com/article/formula#{token})
        ",
        @"
{token}()
        "
    )]
    [ParserOperation]
    public class TodayUTC : PrefixOperationToken
    {

        public override string Name { get { return "TodayUTC"; } }
        public override int MinOperandCount { get { return 0; } }
        public override int MaxOperandCount { get { return 0; } }
        public override bool Symbolic { get { return false; } }

        public override object EvalValue(Func<string, object> context)
        {
            return DateTime.UtcNow.Date;
        }
    }
}
