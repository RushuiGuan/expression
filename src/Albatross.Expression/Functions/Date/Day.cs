using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using System.Xml;
using Albatross.Expression.Exceptions;


namespace Albatross.Expression.Operations
{
    [ParserOperation]
    public class Day : PrefixOperationToken
    {

        public override string Name { get { return "day"; } }
        public override int MinOperandCount { get { return 1; } }
        public override int MaxOperandCount { get { return 1; } }
        public override bool Symbolic { get { return false; } }

        public override object EvalValue(Func<string, object> context)
        {
            object a = Operands.First().EvalValue(context);
            if (a == null) { return null; }
            if (a is DateTime)
            {
                return Convert.ToDouble(((DateTime)a).Day);
            }
            else
            {
                DateTime datetime;
                if (DateTime.TryParse(Convert.ToString(a), out datetime))
                {
                    return Convert.ToDouble(datetime.Day);
                }
                else
                {
                    throw new FormatException("Invalid Datetime Format");
                }
            }
        }
    }
}
