using Albatross.Expression.Documentation;
using Albatross.Expression.Documentation.Attributes;
using Albatross.Expression.Exceptions;
using Albatross.Expression.Tokens;
using System;

namespace Albatross.Expression.Operations
{
    [OperationDoc(Group.Boolean, "{token}", @"### Subtract two numeric values.")]
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
