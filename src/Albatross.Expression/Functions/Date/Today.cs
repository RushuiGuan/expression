using Albatross.Expression.Documentation;
using Albatross.Expression.Documentation.Attributes;
using Albatross.Expression.Tokens;
using System;

namespace Albatross.Expression.Operations
{
    [FunctionDoc(Group.Date, "{token}()",
@"### Create date object represent current date in the tenant timezone
#### Inputs:
- No inputs
#### Outputs:
- Date."
    )]
    [ParserOperation]
    public class Today : PrefixOperationToken
    {

        public override string Name { get { return "Today"; } }
        public override int MinOperandCount { get { return 0; } }
        public override int MaxOperandCount { get { return 0; } }
        public override bool Symbolic { get { return false; } }

        public override object EvalValue(Func<string, object> context)
        {
            var now = DateTime.Now;

            if (Config.NowFunction.DateTimeKind == DateTimeKind.Utc)
                now = DateTime.UtcNow;

            if (Config.NowFunction.Normalizer != null)
                now = Config.NowFunction.Normalizer(now);

            return now.Date;
        }
    }
}
