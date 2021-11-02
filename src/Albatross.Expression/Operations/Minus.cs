using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using System.Xml;
using Albatross.Expression.Exceptions;
using Albatross.Expression.Documentation.Attributes;
using Albatross.Expression.Documentation;

namespace Albatross.Expression.Operations
{
    [OperationDoc(Group.Boolean, "@v1 {token} @v2",
        @"
### Subtract two numeric values.

#### References:
- [{token}](https://help.workiom.com/article/formula#{token})
        ",
        @"
2 {token} 1
        "
    )]
    [ParserOperation]
    public class Minus : InfixOperationToken
    {

        public override string Name { get { return "-"; } }
        public override bool Symbolic { get { return true; } }
        public override int Precedence { get { return 100; } }

        public override object EvalValue(Func<string, object> context)
        {
            object a = Operand1.EvalValue(context);
            object b = Operand2.EvalValue(context);

            if (a == null || b == null)
            {
                return null;
            }
            else if (double.TryParse(a.ToString(), out double aNumber) && double.TryParse(b.ToString(), out double bNumber))
            {
                return aNumber - bNumber;
            }
            else if (a is DateTime && b is double)
            {
                return ((DateTime)a).AddDays(-1 * Convert.ToDouble(b));
            }
            else
            {
                throw new UnexpectedTypeException(a.GetType());
            }
        }
    }
}
