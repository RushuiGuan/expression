using Albatross.Expression.Exceptions;
using Albatross.Expression.Operations;
using Albatross.Expression.Tokens;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Albatross.Expression.Test
{
    [TestFixture]
    [Category("Operations")]
    public class DateOperationTests
    {
        [TestCase("day(\"2015-5-14\")", ExpectedResult = 14)]
        [TestCase("month(\"2015-5-1\")", ExpectedResult = 5)]
        [TestCase("year(\"2015-1-1\")", ExpectedResult = 2015)]
        [TestCase("Date(\"2015-2-10\") = createDate(2015, 2, 10)", ExpectedResult = true)]
        [TestCase("createDate(2015, 2, 14) = Date(\"2015-2-14\")", ExpectedResult = true)]

        // Month Name
        [TestCase("monthName(1)", ExpectedResult = "January")]
        [TestCase("shortMonthName(1)", ExpectedResult = "Jan")]
       
        // Add working days
        [TestCase("day(addWorkingDays(\"2021-7-5\", 10))", ExpectedResult = 19)]
        [TestCase("day(addWorkingDays(\"2021-7-16\", 1))", ExpectedResult = 19)]

        // Date + / - Days
        [TestCase("Date(\"2015-2-10\") - 3 = Date(\"2015-2-7\")  ", ExpectedResult = true)]
        [TestCase("Date(\"2015-2-10\") + 4 = Date(\"2015-2-14\")  ", ExpectedResult = true)]

        // Subtract
        [TestCase("SubtractDate(CreateDate(2020, 1, 4), CreateDate(2020, 1, 1))", ExpectedResult = 3)]
        [TestCase("SubtractTime(CreateDate(2020, 1, 1, 11, 15, 0), CreateDate(2020, 1, 1, 10, 14, 0))", ExpectedResult = 61)]
        [TestCase("SubtractTime(CreateDate(2020, 1, 1), CreateDate(2020, 1, 1))", ExpectedResult = 0)]



        // Format
        [TestCase("Format(CreateDate(1985, 5,27), \"yyyy-MM-dd\")", ExpectedResult = "1985-05-27")]
        [TestCase("format(Date(\"2015-2-10\"), \"yyyy-MM-dd\")", ExpectedResult = "2015-02-10")]
        [TestCase("GetWorkingDays(Date(\"2023-08-29\"), Date(\"2023-09-03\"),1,1)", ExpectedResult = 4d)]

        public object OperationsTesting(string expression)
        {
            return Factory.Instance.Create().Compile(expression).EvalValue(null);
        }
    }
}
