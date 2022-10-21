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
    public class TextOperationTests
    {
        // Padding
        [TestCase("padleft(1, 3)", ExpectedResult = "  1")]
        [TestCase("padleft(1, 3, 0)", ExpectedResult = "001")]
        [TestCase("padleft(1111, 3, 0)", ExpectedResult = "1111")]

        [TestCase("padright(1, 3)", ExpectedResult = "1  ")]
        [TestCase("padright(1, 3, 0)", ExpectedResult = "100")]
        [TestCase("padright(1111, 3, 0)", ExpectedResult = "1111")]


        // Right & Left
        [TestCase("left(\"abc\", 2)", ExpectedResult = "ab")]
        [TestCase("left(\"abc\", 0)", ExpectedResult = "")]
        [TestCase("left(\"abc\", 3)", ExpectedResult = "abc")]
        [TestCase("left(\"abc\", 10)", ExpectedResult = "abc")]
        [TestCase("right(\"123456789\", 8)", ExpectedResult = "23456789")]
        [TestCase("right(\"123456789\", 1)", ExpectedResult = "9")]
        [TestCase("right(\"123456789\", 0)", ExpectedResult = "")]
        [TestCase("right(\"123456789\", 9)", ExpectedResult = "123456789")]
        [TestCase("right(\"123456789\", 100)", ExpectedResult = "123456789")]
        [TestCase("right(\"123456789\", 100)", ExpectedResult = "123456789")]

        // Index Of
        [TestCase("indexof(\"123456789\", \"3\")", ExpectedResult = 2)]
        [TestCase("indexof(\"123456789\", \"a\")", ExpectedResult = -1)]
        [TestCase("indexof(\"121212\", \"2\")", ExpectedResult = 1)]
        [TestCase("indexof(\"hom.rcp@gmail.com\", \"@\")", ExpectedResult = 7)]
        [TestCase("indexof(\"hom.rcp@gmail.com\", \"@\") - 1", ExpectedResult = 6)]
        [TestCase("indexof(\"hom.rcp@gmail.com\", \"XYZ\") ", ExpectedResult = -1)] // does not exist

        // Replace
        [TestCase("replace(\"Hello World\", \"l\", \"x\")", ExpectedResult = "Hexxo Worxd")]
        [TestCase("replace(\"1 2 3 4 5\", \" \", \" - \")", ExpectedResult = "1 - 2 - 3 - 4 - 5")]

        // Trim
        [TestCase("trim(\" Ahmad   \")", ExpectedResult = "Ahmad")]
        [TestCase("trimRight(\" Ahmad   \")", ExpectedResult = " Ahmad")]
        [TestCase("trimLeft(\" Ahmad   \")", ExpectedResult = "Ahmad   ")]

        // General
        [TestCase("format(1000, \"#,#\")", ExpectedResult = "1,000")]
        [TestCase("Text(1)", ExpectedResult = "1")]

        // Compound
        [TestCase("if(indexof(\"something in germany\" , \"germany\") <> -1, true , false)", ExpectedResult = true)]
        [TestCase("if(indexof(\"something in germany\" , \"germany\") <> Number(\"-1\") ,True ,False )", ExpectedResult = true)]

        [TestCase("substring(\"123456789\", 3)", ExpectedResult = "456789")]
        [TestCase("substring(\"123456789\", 5)", ExpectedResult = "6789")]
        [TestCase("substring(\"123456789\", 0, 2)", ExpectedResult = "12")]
        [TestCase("substring(\"123\", 3)", ExpectedResult = "")]
        [TestCase("substring(\"hom.rcp@gmail.com\", 8)", ExpectedResult = "gmail.com")]

        [TestCase("substring(\"hom.rcp@gmail.com\", indexof(\"hom.rcp@gmail.com\", \"@\"))", ExpectedResult = "@gmail.com")]
        [TestCase("concat(true,5, 8,\"-variable\")", ExpectedResult = "58-variable")]
        public object OperationsTesting(string expression)
        {
            return Factory.Instance.Create().Compile(expression).EvalValue(null);
        }
    }
}
