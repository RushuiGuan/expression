using Albatross.Expression.Exceptions;
using Albatross.Expression.Tokens;
using System;
using System.Collections.Generic;
using Albatross.Expression.Documentation.Attributes;
using Albatross.Expression.Documentation;

namespace Albatross.Expression.Operations
{
    [FunctionDoc(Group.Text, "{token}(@text,@oldValue,@newValue)",
        @"
### Replace all occurence of the oldValue with the newValue in the text.
#### Inputs:
- text: String
- oldValue: String
- newValue: String
#### Outputs:
- String

#### References:
- [{token}](https://help.workiom.com/article/formula#{token})
        ",
        @"
{token}(""Old text"",""New text"")
        "
    )]
    [ParserOperation]
    public class Replace : PrefixOperationToken
    {
        public override string Name { get { return "replace"; } }
        public override int MinOperandCount { get { return 3; } }
        public override int MaxOperandCount { get { return 3; } }
        public override bool Symbolic { get { return false; } }

        public override object EvalValue(Func<string, object> context)
        {
            List<object> list = GetOperands(context);
            if (list.Count == 0)
                return null;

            if (list.Count != 3)
            {
                throw new OperandException("Replace function expects 3 operand");
            }

            object value1 = list[0];
            object value2 = list[1];
            object value3 = list[2];

            string text;
            string oldValue;
            string newValue;

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
                oldValue = Convert.ToString(value2);
            }
            else
            {
                throw new UnexpectedTypeException(value2.GetType());
            }

            if (value3 is string)
            {
               newValue = Convert.ToString(value3);
            }
            else
            {
                throw new UnexpectedTypeException(value2.GetType());
            }



            return text.Replace(oldValue,newValue);
        }
    }
}
