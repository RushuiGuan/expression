using Albatross.Expression.Exceptions;
using Albatross.Expression.Tokens;
using System;
using System.Collections.Generic;
using Albatross.Expression.Documentation.Attributes;
using Albatross.Expression.Documentation;

namespace Albatross.Expression.Operations
{
    [FunctionDoc(Group.Text, "{token}(@text,@index)",
        @"
### Returns the rest of the string as a substring after the given index number.
#### Inputs:
- text: String
- index: Number
#### Outputs:
- String

#### References:
- [{token}](https://help.workiom.com/article/formula#{token})
        ",
        @"
{token}(""Hello World"", 5)
        "
    )]
    [ParserOperation]
    public class Substring : PrefixOperationToken
    {
        public override string Name { get { return "Substring"; } }
        public override int MinOperandCount { get { return 2; } }
        public override int MaxOperandCount { get { return 3; } }
        public override bool Symbolic { get { return false; } }

        public override object EvalValue(Func<string, object> context)
        {
            List<object> list = GetOperands(context);
            if (list.Count <= 0)
                return null;

            object value1 = list[0];
            object value2 = list[1];


            string text;
            int start;
            int? length = null;

            if (value1 == null)
                return null;


            if (value1 is string)
            {
                text = Convert.ToString(value1);
            }
            else
            {
                throw new UnexpectedTypeException(value1.GetType());
            }

            if (value2 is int)
            {
                start = (int)value2;
            }
            else if (value2 is double)
            {
                start = (int)Math.Round((double)value2, 0);
            }
            else
            {
                throw new UnexpectedTypeException(value2.GetType());
            }

            if (start < 0)
            {
                throw new OperandException("Substring function expects a positive number for the second and third operand");
            }

            if (list.Count == 3)
            {
                object value3 = list[2];
                if (value2 == null)
                    return -1;

                if (value3 is double)
                {
                    length = (int)Math.Round((double)value3, 0);
                }
                else
                {
                    throw new UnexpectedTypeException(value3.GetType());
                }
            }

            if (length < 0)
            {
                throw new OperandException("Substring function expects a positive number for the second and third operand");
            }

            if (start > text.Length)
            {
                throw new OperandException("Substring function should be less or equal than the length of the text");
            }

            if (length == null)
                return text.Substring(start);

            return text.Substring(start, length.Value);
        }
    }
}
