using Albatross.Expression.Documentation;
using Albatross.Expression.Documentation.Attributes;
using Albatross.Expression.Tokens;
using System;
using System.Linq;

namespace Albatross.Expression.Operations
{
    /// <summary>
    /// <para>Prefix operation that create an date</para>
    /// <para>Operand Count: 3</para>
    /// <list type="number">
    ///		<listheader>
    ///		<description>Operands</description>
    ///		</listheader>
    ///		<item><description>year : double</description></item>
    ///		<item><description>month : double</description></item>
    ///		<item><description>day : double</description></item>
    /// </list>
    /// <para>Operand Type: int</para>
    /// <para>Output Type: System.DateTime</para>
    /// <para>Usage: Create
    /// 2018, 1, 31)</para>
    /// <para>Usage: CreateDate(2018, 1, 31, 10,10,00)</para>
    /// </summary>
    [FunctionDoc(Group.Date, "{token}(@year,@month,@day,@hour,@minute,@second)",
        @"
### Create new date, date time

#### Inputs:
- year: double
- month: double
- day: double
- hour: double (optional)
- minute: double (optional)
- second: double (optional)

#### Outputs:
- Date or Date with time.

#### References:
- [{token}](https://help.workiom.com/article/formula#{token})
        ",
        @"
{token}(2021, 12, 31)
{token}(2021, 12, 31, 11)
{token}(2021, 12, 31, 11, 59)
{token}(2021, 12, 31, 11, 59, 59)
        "
    )]
    [ParserOperation]
    public class CreateDate : PrefixOperationToken
    {
        public override string Name { get { return "createDate"; } }
        public override int MinOperandCount { get { return 3; } }
        public override int MaxOperandCount { get { return 6; } }
        public override bool Symbolic { get { return false; } }

        public override object EvalValue(Func<string, object> context)
        {
            var input = Operands.Select(item => (int)Convert.ChangeType(item.EvalValue(context), typeof(int))).ToArray();
            var year = input[0];
            var month = input[1];
            var day = input[2];
            var hour = 0;
            var minute = 0;
            var second = 0;

            if (input.Count() > 3)
                hour = input[3];

            if (input.Count() > 4)
                minute = input[4];

            if (input.Count() > 5)
                second = input[5];

            if (input.Count() > 6)
                throw new FormatException("Invalid Datetime input. max inputs count is 6 (year, month, date, hours, minutes, seconds)");

            return new DateTime(year, month, day, hour, minute, second);
        }
    }
}
