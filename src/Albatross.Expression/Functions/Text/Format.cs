using Albatross.Expression.Documentation.Attributes;
using Albatross.Expression.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Albatross.Expression.Operations
{
    /// <summary>
    /// <para>Prefix operation that will take an input and C# format string and produced a formatted string</para>
    /// 
    /// </summary>
    [FunctionDoc(Documentation.Group.Text, "{token}( , )",
        @"
		### Format
		#### Inputs:
		- data: Object
		- format: String

		#### Outputs:
		- formatted string.
		"
    )]
    [ParserOperation]
    public class Format : PrefixOperationToken
    {

        public override string Name { get { return "Format"; } }
        public override int MinOperandCount { get { return 2; } }
        public override int MaxOperandCount { get { return 2; } }
        public override bool Symbolic { get { return false; } }


        public override object EvalValue(Func<string, object> context)
        {
            List<object> list = GetOperands(context);
            string format = "{0:" + list.Last() + "}";
            return string.Format(format, list.First());
        }
    }
}
