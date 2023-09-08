using Albatross.Expression.Documentation;
using Albatross.Expression.Documentation.Attributes;
using Albatross.Expression.Exceptions;
using Albatross.Expression.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Albatross.Expression.Operations
{
    [FunctionDoc(Group.Text, "{token}( )",
@"### Returns the number of characters in a string.
#### Inputs:
- string: String
#### Outputs:
- Integer"
    )]
    [ParserOperation]
    public class Len : PrefixOperationToken
    {

        public override string Name { get { return "Len"; } }
        public override int MinOperandCount { get { return 1; } }
        public override int MaxOperandCount { get { return 1; } }
        public override bool Symbolic { get { return false; } }

        public override object EvalValue(Func<string, object> context)
        {
            List<object> list = GetOperands(context);

            object value = list[0];
            if (value == null)
            {
                return null;
            }
            else if (value is ICollection)
            {
                return Convert.ToDouble(((ICollection)value).Count);
            }
            if (value is string)
            {
                return Convert.ToDouble(((string)value).Length);
            }
            else
            {
                throw new UnexpectedTypeException(value.GetType());
            }
        }
    }
}
