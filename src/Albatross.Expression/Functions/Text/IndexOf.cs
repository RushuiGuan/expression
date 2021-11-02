using Albatross.Expression.Exceptions;
using Albatross.Expression.Tokens;
using System;
using System.Collections.Generic;
using Albatross.Expression.Documentation.Attributes;
using Albatross.Expression.Documentation;

namespace Albatross.Expression.Operations
{
    [FunctionDoc(Group.Text, "{token}(@text,@value)",
        @"
### Return index of value in the text
#### Inputs:
- text: String
- value: String

#### Outputs:
- Zero based index position if the value is found, or -1 if not found.

#### References:
- [{token}](https://help.workiom.com/article/formula#{token})
        ",
        @"
{token}(""Some text"", ""Some"")
        "
    )]
    [ParserOperation]
    public class IndexOf : PrefixOperationToken
    {
        public override string Name { get { return "IndexOf"; } }
        public override int MinOperandCount { get { return 2; } }
        public override int MaxOperandCount { get { return 2; } }
        public override bool Symbolic { get { return false; } }

        public override object EvalValue(Func<string, object> context)
        {
            List<object> list = GetOperands(context);
            if (list.Count == 0)
                return null;

            object value1 = list[0];
            object value2 = list[1];

            string text;
            string value;

            if (value1 == null)
                return null;

            if (value2 == null)
                return -1;

            if (value1 is string)
            {
                text = Convert.ToString(value1);
            }
            else
            {
                throw new UnexpectedTypeException(value1.GetType());
            }

            if (value2 is string)
            {
                value = Convert.ToString(value2);
            }
            else
            {
                throw new UnexpectedTypeException(value2.GetType());
            }


            return (double)text.IndexOf(value);
        }
    }
}
