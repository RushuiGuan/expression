using Albatross.Expression.Exceptions;
using Albatross.Expression.Tokens;
using System;
using System.Collections.Generic;

namespace Albatross.Expression.Operations
{
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


            return text.IndexOf(value);
        }
    }
}
