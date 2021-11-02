using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using System.Xml;
using Albatross.Expression.Exceptions;
using System.Collections;
using Albatross.Expression.Documentation.Attributes;
using Albatross.Expression.Documentation;

namespace Albatross.Expression.Operations
{
    [FunctionDoc(Group.Text, "{token}(@string)",
        @"
### Returns the number of characters in a string.
#### Inputs:
- string: String
#### Outputs:
- Integer

#### References:
- [{token}](https://help.workiom.com/article/formula#{token})
        ",
        @"
{token}(""Hello World"")
        "
    )]
    [ParserOperation]
    public class Len : PrefixOperationToken
    {

        public override string Name { get { return "len"; } }
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
                return ((ICollection)value).Count;
            }
            if (value is string)
            {
                return ((string)value).Length;
            }
            else
            {
                throw new UnexpectedTypeException(value.GetType());
            }
        }
    }
}
