using Albatross.Expression.Documentation;
using Albatross.Expression.Documentation.Attributes;

namespace Albatross.Expression.Operations
{
    /// <summary>
    /// <para>Infix operation that perform an equal check</para>
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
    [OperationDoc(Group.Boolean, "{token}", @"### Returns true if the both sides of the equation are the same ")]
    [ParserOperation]
    public class Equal : ComparisonInfixOperation
    {

        public override string Name { get { return "="; } }
        public override bool Symbolic { get { return true; } }
        public override int Precedence { get { return 50; } }

        public override bool interpret(int comparisonResult)
        {
            return comparisonResult == 0;
        }
    }
}
