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
    public class GeneralOperationTests
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
        [TestCase("13/3", ExpectedResult = 4.333)]
        [TestCase("5/2", ExpectedResult = 2.500)]
        [TestCase("15/2", ExpectedResult = 7.500)]
        [TestCase("19/4", ExpectedResult = 4.750)]
        [TestCase("22/7", ExpectedResult = 3.143)]
        [TestCase("4/0", ExpectedResult = double.PositiveInfinity)]

        [TestCase("-12", ExpectedResult = -12)]
        [TestCase("+12", ExpectedResult = 12)]

        [TestCase("-  12", ExpectedResult = -12)]
        [TestCase("+  12", ExpectedResult = 12)]

        [TestCase("1-2", ExpectedResult = -1)]
        [TestCase("1-null", ExpectedResult = null)]

        [TestCase("1 + 2", ExpectedResult = 3)]
        [TestCase("1+null", ExpectedResult = null)]

        [TestCase("null%3", ExpectedResult = null)]
        [TestCase("2%3", ExpectedResult = 2)]

        [TestCase("2^3", ExpectedResult = 8)]
        [TestCase("2^null", ExpectedResult = null)]
        [TestCase("null^2", ExpectedResult = null)]
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
        [TestCase("substring(\"123456789\", -5)", typeof(OperandException))]
        [TestCase("substring(\"123456789\", 100)", typeof(OperandException))]
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
