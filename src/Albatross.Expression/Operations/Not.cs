using Albatross.Expression.Documentation;
using Albatross.Expression.Documentation.Attributes;
using Albatross.Expression.Tokens;
using System;
using System.Linq;

namespace Albatross.Expression.Operations
{
    [OperationDoc(Group.Boolean, "{token}", @"### Returns true if the operand is not true.")]
    [ParserOperation]
    public class Not : PrefixOperationToken
    {
        public override string Name { get { return "Not"; } }
        public override int MinOperandCount { get { return 1; } }
        public override int MaxOperandCount { get { return 1; } }
        public override bool Symbolic { get { return false; } }

        public override object EvalValue(Func<string, object> context)
        {
            object value = Operands.First().EvalValue(context);
            return !value.ConvertToBoolean();
        }
    }
}
