using Albatross.Expression.Documentation;
using Albatross.Expression.Documentation.Attributes;

namespace Albatross.Expression.Operations
{
    [OperationDoc(Group.Boolean, "{token}", @"### Returns true if the first numeric value is less than or equal to the second numeric value. ")]
    [ParserOperation]
    public class LessEqual : ComparisonInfixOperation
    {

        public override string Name { get { return "<="; } }
        public override bool Symbolic { get { return true; } }
        public override int Precedence { get { return 50; } }

        public override bool interpret(int comparisonResult)
        {
            return comparisonResult <= 0;
        }
    }
}
