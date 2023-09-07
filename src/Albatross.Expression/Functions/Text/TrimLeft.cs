using Albatross.Expression.Documentation;
using Albatross.Expression.Documentation.Attributes;
using Albatross.Expression.Tokens;
using System;
using System.Linq;

namespace Albatross.Expression.Operations
{
    [FunctionDoc(Group.Text, "{token}( )",
        @"
		### Removes the empty spaces from the beginning of the string.
		#### Inputs:
		- string: String

		#### Outputs:
		- String
		"
    )]
    [ParserOperation]
    public class TrimLeft : PrefixOperationToken
    {

        public override string Name { get { return "TrimLeft"; } }
        public override int MinOperandCount { get { return 1; } }
        public override int MaxOperandCount { get { return 1; } }
        public override bool Symbolic { get { return false; } }

        public override object EvalValue(Func<string, object> context)
        {
            object value = Operands.First().EvalValue(context);
            return Convert.ToString(value).TrimStart();
        }
    }
}
