using Albatross.Expression.Documentation;
using Albatross.Expression.Documentation.Attributes;
using Albatross.Expression.Tokens;
using System;

namespace Albatross.Expression.Operations
{
    /// <summary>
    /// <para>Infix operation that perform divide</para>
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
    [OperationDoc(Group.Boolean, "{token}", @"### Divide two numeric values")]
    [ParserOperation]
    public class Divide : InfixOperationToken
    {

        public override string Name { get { return "/"; } }
        public override bool Symbolic { get { return true; } }
        public override int Precedence { get { return 200; } }

        public override object EvalValue(Func<string, object> context)
        {
            object a = Operand1.EvalValue(context);
            object b = Operand2.EvalValue(context);

            if (a == null || b == null) { return null; }

            if (a is double && b is double)
            {
                var result = Math.Round((double)a / (double)b, 3);
                return result;
            }
            else
            {
                throw new Exceptions.UnexpectedTypeException(a.GetType());
            }
        }
    }
}