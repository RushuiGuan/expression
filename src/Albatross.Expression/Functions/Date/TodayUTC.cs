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
            if (Config.NowFunction.Normalizer != null)
            {
                var now = DateTime.Now;
                if (Config.NowFunction.DateTimeKind == DateTimeKind.Utc)
                    now = DateTime.UtcNow;

                var normalizedNow = Config.NowFunction.Normalizer(now);
                var dif = (normalizedNow - now).TotalHours;

                return normalizedNow.Date.AddHours(-1 * dif);
            }

            return DateTime.Today;
        }
    }
}
