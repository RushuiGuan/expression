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
        [TestCase("coalesce(2, 1)", ExpectedResult = 2)]
        [TestCase("coalesce(null, 1)", ExpectedResult = 1)]

        [TestCase("max(1, 2, 3)", ExpectedResult = 3)]
        [TestCase("max(1, 2, null)", ExpectedResult = 2)]

        [TestCase("min(1, 2, 3)", ExpectedResult = 1)]
        [TestCase("min(null, 1, 3)", ExpectedResult = 1)]

        //other functions
        [TestCase("avg(3, 4, 5 )", ExpectedResult = 4)]
        [TestCase("avg(null, 4, 5 )", ExpectedResult = 4.5)]
        [TestCase("avg(0, 4, 5 )", ExpectedResult = 3)]
        [TestCase("avg(@(0, 4, 5))", ExpectedResult = 3)]

        // Random
        [TestCase("getRandom() > 0", ExpectedResult = true)]
        [TestCase("getRandom(10) > 0 and getRandom(10, 100) < 100", ExpectedResult = true)]
        [TestCase("getRandom(10, 100) > 10 and getRandom(10, 100) < 100", ExpectedResult = true)]
        [TestCase("getRandom(10, 100) < 10 or getRandom(10, 100) > 100", ExpectedResult = false)]

        // Round
        [TestCase("round(1.4)", ExpectedResult = 1)]
        [TestCase("round(1.431412, 2)", ExpectedResult = 1.43)]
        [TestCase("round(1.4991412, 2)", ExpectedResult = 1.5)]

        [TestCase("roundUp(50.99)", ExpectedResult = 51)]
        [TestCase("roundDown(50.99)", ExpectedResult = 50)]

        [TestCase("Number(\"44\")", ExpectedResult = 44)]
        [TestCase("SubtractTime(Date(\"2022-10-10 10:20:10\"),Date(\"2022-10-10 10:10:13\"))", ExpectedResult = 10)]
        public object OperationsTesting(string expression)
        {
            return Factory.Instance.Create().Compile(expression).EvalValue(null);
        }
    }
}
