using Albatross.Expression.Documentation;
using Albatross.Expression.Documentation.Attributes;
using Albatross.Expression.Tokens;
using System;

namespace Albatross.Expression.Functions.Date
{
    [FunctionDoc(Group.Date, "{token}( , )",
        @"
        ### Add working days
        #### Inputs:
        - date: Date
        - day: Number

        #### Outputs:
        - Date at working time from Mondey to Friday.
        "
    )]
    [ParserOperation]
    public class AddWorkingDays : PrefixOperationToken
    {
        public override string Name { get { return "addWorkingDays"; } }
        public override int MinOperandCount { get { return 2; } }
        public override int MaxOperandCount { get { return 2; } }
        public override bool Symbolic { get { return false; } }

        public override object EvalValue(Func<string, object> context)
        {
            object date = (DateTime)Convert.ChangeType(Operands[0].EvalValue(context), typeof(DateTime));
            object days = (int)Convert.ChangeType(Operands[1].EvalValue(context), typeof(int));

            return AddWorkdays((DateTime)date, (int)days);
        }

        private DateTime AddWorkdays(DateTime originalDate, int workDays)
        {
            DateTime tmpDate = originalDate;
            while (workDays > 0)
            {
                tmpDate = tmpDate.AddDays(1);
                if (tmpDate.DayOfWeek < DayOfWeek.Saturday &&
                    tmpDate.DayOfWeek > DayOfWeek.Sunday
                    // && !tmpDate.IsHoliday()
                    )
                    workDays--;
            }
            return tmpDate;
        }
    }
}