using Albatross.Expression.Documentation;
using Albatross.Expression.Documentation.Attributes;
using Albatross.Expression.Tokens;
using System;
using System.Linq;

namespace Albatross.Expression.Operations
{
    /// <summary>
    /// <para>Prefix operation to check if the input IsBlank</para>
    /// <para>Operand Type: any</para>
    /// <para>Null, empty string and string with only white space are considered as blank</para>
    /// </summary>
    [FunctionDoc(Group.Text, "{token}( )",
@"### Returns boolean value, true if the value is blank, false if not.  Null, empty string, string with only white space are considered as blank.
#### Inputs:
- value: String
#### Outputs:
- Boolean"
    )]
    [ParserOperation]
    public class IsBlank : PrefixOperationToken
    {

        public override string Name { get { return "IsBlank"; } }
        public override int MinOperandCount { get { return 1; } }
        public override int MaxOperandCount { get { return 1; } }
        public override bool Symbolic { get { return false; } }

        public override object EvalValue(Func<string, object> context)
        {
            object value = GetOperands(context).First();

            if (value == null)
            {
                return true;
            }
            else if (value is string)
            {
                return string.IsNullOrWhiteSpace((string)value);
            }
            else
            {
                return false;
            }
        }
    }
}
