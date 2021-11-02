using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using System.Xml;
using Albatross.Expression.Documentation.Attributes;
using Albatross.Expression.Documentation;

namespace Albatross.Expression.Operations
{
    /// <summary>
    /// <para>Infix operation that perform an plus operation</para>
    /// <para>Operand Count: 2</para>
    /// <list type="number">
    ///		<listheader>
    ///		<description>Operands</description>
    ///		</listheader>
    ///		<item><description>Operrand1 : double</description></item>
    ///		<item><description>Operrand2 : double</description></item>
    /// </list>
    /// <para>Output Type: double</para>
    /// </summary>
    [OperationDoc(Group.Boolean, "@v1 {token} @v2",
        @"
### Add together two numeric values.

#### References:
- [{token}](https://help.workiom.com/article/formula#{token})
        ",
        @"
2 {token} 1
        "
    )]
    [ParserOperation]
    public class Plus : InfixOperationToken
    {

        public override string Name { get { return "+"; } }
        public override bool Symbolic { get { return true; } }
        public override int Precedence { get { return 100; } }

        public override object EvalValue(Func<string, object> context)
        {
            object a = Operand1.EvalValue(context);
            object b = Operand2.EvalValue(context);

            if (a == null || b == null) { return null; }

            else if (double.TryParse(a.ToString(), out double aNumber) && double.TryParse(b.ToString(), out double bNumber))
            {
                return aNumber + bNumber;
            }
            else if (a is DateTime && double.TryParse(b.ToString(), out bNumber))
            {
                return ((DateTime)a).AddDays(bNumber);
            }
            else if (a is string || b is string)
            {
                return string.Format("{0}{1}", a, b);
            }
            else
            {
                throw new Exceptions.UnexpectedTypeException(a.GetType());
            }
        }
    }
}
