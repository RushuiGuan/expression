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
    public class ArrayOperationTests
    {

        [TestCase("len(@(null, 1, 3))", ExpectedResult = 3)]
        [TestCase("len(\"abc\")", ExpectedResult = 3)]
        [TestCase("len(@(1,2,3))", ExpectedResult = 3)]
        [TestCase("len(@(1,2,3)) + 1", ExpectedResult = 4)]
        public object OperationsTesting(string expression)
        {
            return Factory.Instance.Create().Compile(expression).EvalValue(null);
        }
    }
}
