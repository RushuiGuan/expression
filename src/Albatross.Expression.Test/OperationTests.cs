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
    public class OperationTests
    {
        //logical
        [TestCase("true and 1", ExpectedResult = true)]
        [TestCase("1 and 1", ExpectedResult = true)]
        [TestCase("null and 1", ExpectedResult = false)]

        [TestCase("not(1)", ExpectedResult = false)]

        [TestCase("0 or \"\"", ExpectedResult = true)]  //blank string is considered as true
        [TestCase("1 or false", ExpectedResult = true)]
        [TestCase("1 or null", ExpectedResult = true)]
        [TestCase("null or 1", ExpectedResult = true)]
        [TestCase("1=2", ExpectedResult = false)]
        [TestCase("1=1", ExpectedResult = true)]

        [TestCase("1>=1", ExpectedResult = true)]
        [TestCase("2>=1", ExpectedResult = true)]
        [TestCase("1>=2", ExpectedResult = false)]
        [TestCase("1>=null", ExpectedResult = false)]

        [TestCase("1<=1", ExpectedResult = true)]
        [TestCase("2<=1", ExpectedResult = false)]
        [TestCase("1<=2", ExpectedResult = true)]
        [TestCase("1<=null", ExpectedResult = false)]

        [TestCase("1<1", ExpectedResult = false)]
        [TestCase("2<1", ExpectedResult = false)]
        [TestCase("1<2", ExpectedResult = true)]
        [TestCase("1<null", ExpectedResult = false)]

        [TestCase("1>1", ExpectedResult = false)]
        [TestCase("2>1", ExpectedResult = true)]
        [TestCase("1>2", ExpectedResult = false)]
        [TestCase("1>null", ExpectedResult = false)]

        [TestCase("1<>1", ExpectedResult = false)]
        [TestCase("1<>2", ExpectedResult = true)]
        [TestCase("1<>null", ExpectedResult = false)]
        [TestCase("1+2<1+3", ExpectedResult = true)]

        [TestCase("if(1, 1, 2)", ExpectedResult = 1)]
        [TestCase("if(0, 1, 2)", ExpectedResult = 2)]
        [TestCase("if(null, 1, 2)", ExpectedResult = 2)]    //null is false when used as logical input value

        //arithmatic
        [TestCase("2*3", ExpectedResult = 6)]
        [TestCase("2*null", ExpectedResult = null)]

        [TestCase("4/2", ExpectedResult = 2)]
        [TestCase("4/0", ExpectedResult = double.PositiveInfinity)]

        [TestCase("-12", ExpectedResult = -12)]
        [TestCase("+12", ExpectedResult = 12)]

        [TestCase("-  12", ExpectedResult = -12)]
        [TestCase("+  12", ExpectedResult = 12)]

        [TestCase("1-2", ExpectedResult = -1)]
        [TestCase("1-null", ExpectedResult = null)]

        [TestCase("1+2", ExpectedResult = 3)]
        [TestCase("1+null", ExpectedResult = null)]

        [TestCase("null%3", ExpectedResult = null)]
        [TestCase("2%3", ExpectedResult = 2)]

        [TestCase("2^3", ExpectedResult = 8)]
        [TestCase("2^null", ExpectedResult = null)]
        [TestCase("null^2", ExpectedResult = null)]

        //text
        [TestCase("isblank(\"\")", ExpectedResult = true)]
        [TestCase("isblank(\"   \")", ExpectedResult = true)]
        [TestCase("isblank(\" a  \")", ExpectedResult = false)]
        [TestCase("isblank(null)", ExpectedResult = true)]

        [TestCase("month(\"2015-5-1\")", ExpectedResult = 5)]
        [TestCase("MonthName(1)", ExpectedResult = "January")]
        [TestCase("ShortMonthName(1)", ExpectedResult = "Jan")]
        [TestCase("Text(1)", ExpectedResult = "1")]
        [TestCase("toNumber(\"44\")", ExpectedResult = 44)]
        [TestCase("Year(\"2015-1-1\")", ExpectedResult = 2015)]
        [TestCase("Format(Date(\"2015-2-10\"), \"yyyy-MM-dd\")", ExpectedResult = "2015-02-10")]

        //text
        [TestCase("padleft(1, 3)", ExpectedResult = "  1")]
        [TestCase("padleft(1, 3, 0)", ExpectedResult = "001")]
        [TestCase("padleft(1111, 3, 0)", ExpectedResult = "1111")]

        [TestCase("padright(1, 3)", ExpectedResult = "1  ")]
        [TestCase("padright(1, 3, 0)", ExpectedResult = "100")]
        [TestCase("padright(1111, 3, 0)", ExpectedResult = "1111")]

        [TestCase("format(1000, \"#,#\")", ExpectedResult = "1,000")]

        //other functions
        [TestCase("avg(3, 4, 5 )", ExpectedResult = 4)]
        [TestCase("avg(null, 4, 5 )", ExpectedResult = 4.5)]
        [TestCase("avg(0, 4, 5 )", ExpectedResult = 3)]
        [TestCase("avg(@(0, 4, 5))", ExpectedResult = 3)]

        [TestCase("coalesce(2, 1)", ExpectedResult = 2)]
        [TestCase("coalesce(null, 1)", ExpectedResult = 1)]

        [TestCase("max(1, 2, 3)", ExpectedResult = 3)]
        [TestCase("max(1, 2, null)", ExpectedResult = 2)]

        [TestCase("min(1, 2, 3)", ExpectedResult = 1)]
        [TestCase("min(null, 1, 3)", ExpectedResult = 1)]
        [TestCase("len(@(null, 1, 3))", ExpectedResult = 3)]
        [TestCase("len(\"abc\")", ExpectedResult = 3)]
        [TestCase("len(@(1,2,3))", ExpectedResult = 3)]

        [TestCase("left(\"abc\", 2)", ExpectedResult = "ab")]
        [TestCase("left(\"abc\", 0)", ExpectedResult = "")]
        [TestCase("left(\"abc\", 3)", ExpectedResult = "abc")]
        [TestCase("left(\"abc\", 10)", ExpectedResult = "abc")]

        [TestCase("right(\"123456789\", 8)", ExpectedResult = "23456789")]
        [TestCase("right(\"123456789\", 1)", ExpectedResult = "9")]
        [TestCase("right(\"123456789\", 0)", ExpectedResult = "")]
        [TestCase("right(\"123456789\", 9)", ExpectedResult = "123456789")]
        [TestCase("right(\"123456789\", 100)", ExpectedResult = "123456789")]

        [TestCase("Format(CreateDate(1985, 5,27), \"yyyy-MM-dd\")", ExpectedResult = "1985-05-27")]
        [TestCase("SubtractDate(CreateDate(2020, 1, 1), CreateDate(2020, 1, 4))", ExpectedResult = 3)]
        [TestCase("SubtractTime(CreateDate(2020, 1, 1, 10, 14, 0), CreateDate(2020, 1, 1, 11, 15, 0))", ExpectedResult = 61)]
        public object OperationsTesting(string expression)
        {
            return Factory.Instance.Create().Compile(expression).EvalValue(null);
        }


        [TestCase("avg(4, 5,\"x\")", typeof(UnexpectedTypeException))]
        [TestCase("min(4, 5,\"x\")", typeof(UnexpectedTypeException))]
        [TestCase("max(4, 5,\"x\")", typeof(UnexpectedTypeException))]
        [TestCase("1 + today()", typeof(UnexpectedTypeException))]
        [TestCase("monthname(today())", typeof(UnexpectedTypeException))]
        [TestCase("len(today())", typeof(UnexpectedTypeException))]
        [TestCase("left(1234, -1)", typeof(OperandException))]
        [TestCase("right(1234, -1)", typeof(OperandException))]
        public void ParsingFailure(string expression, Type errType)
        {
            TestDelegate handler = new TestDelegate(() =>
            {
                IParser parser = Factory.Instance.Create();
                IToken token = parser.Compile(expression);
                token.EvalValue(null);
            });
            Assert.Throws(errType, handler);
        }
    }
}
