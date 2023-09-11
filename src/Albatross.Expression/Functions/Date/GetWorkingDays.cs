using Albatross.Expression.Documentation;
using Albatross.Expression.Documentation.Attributes;
using Albatross.Expression.Tokens;
using System;
using System.Collections.Generic;

namespace Albatross.Expression.Functions.Date
{
    [FunctionDoc(Group.Date, "{token}( , )",
@"### Get count of working days between two dates
#### Inputs:
- startDate: Date (mandatory)
- endDate: Date (mandatory)
- startOfWeek: Start of week as a value from  1 (Monday) to 7 (Sunday) (Optional), default = 1
- weekendLength: 1 or 2 (Optional), default = 2
#### Outputs:
- number: count of working days."
    )]
    [ParserOperation]
    public class GetWorkingDays : PrefixOperationToken
    {
        public override string Name => "GetWorkingDays";

        public override bool Symbolic => false;

        public override int MinOperandCount => 2;

        public override int MaxOperandCount => 4;

        public override object EvalValue(Func<string, object> context)
        {
            if (ExpressionMode.IsValidationMode)
                return 0M;

            var start = (DateTime)Convert.ChangeType(Operands[0].EvalValue(context), typeof(DateTime));
            var end = (DateTime)Convert.ChangeType(Operands[1].EvalValue(context), typeof(DateTime));

            start = start.Date;
            end = end.Date;

            if (start > end)
            {
                DateTime temp = start;
                start = end;
                end = temp;
            }

            var startOfWeek = DayOfWeek.Monday;
            if (Operands.Count > 2)
                startOfWeek = (DayOfWeek)(((int)Convert.ChangeType(Operands[2].EvalValue(context), typeof(double))) % 7);

            var weekendLength = 2;
            if (Operands.Count > 3)
                weekendLength = ((int)Convert.ChangeType(Operands[3].EvalValue(context), typeof(double))) % 2;

            return CountWorkingDays(start, end, startOfWeek, weekendLength);
        }

        private double CountWorkingDays(DateTime startDate, DateTime endDate, DayOfWeek startOfWeek, int weekendLength)
        {
            double workingDays = 0;
            var workingDaysOfWeek = new List<DayOfWeek>();
            for (int i = (int)startOfWeek; i < (int)startOfWeek + 7 - weekendLength; i++)
                workingDaysOfWeek.Add((DayOfWeek)(i % 7));

            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                if (workingDaysOfWeek.Contains(date.DayOfWeek))
                    workingDays += 1;
            }

            return workingDays;
        }
    }
}
