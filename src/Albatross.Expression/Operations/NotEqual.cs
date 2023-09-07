using Albatross.Expression.Documentation;
using Albatross.Expression.Documentation.Attributes;

namespace Albatross.Expression.Operations
{
    [OperationDoc(Group.Boolean, "{token}",
        @"
		### Returns true if the both sides of the equation are not the same 
		"
    )]
    [ParserOperation]
    public class NotEqual : ComparisonInfixOperation
    {
        public override string Name { get { return "<>"; } }
        public override bool Symbolic { get { return true; } }
        public override int Precedence { get { return 100; } }

        public override bool interpret(int comparisonResult)
        {
            return comparisonResult != 0;
        }
    }
}
