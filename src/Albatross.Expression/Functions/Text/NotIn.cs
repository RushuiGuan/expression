using System;
using System.Linq;
using Albatross.Expression.Documentation.Attributes;
using Albatross.Expression.Tokens;

namespace Albatross.Expression.Functions.Text
{
    [FunctionDoc(Documentation.Group.Text, "{token}( , )",
        @"### Check if a specific text is not part of a set
#### Inputs:
- element: text
- set: List of Text
#### Outputs:
- true or false."
    )]
    [ParserOperation]
    public class NotIn : PrefixOperationToken
    {
        public override string Name => "NotIn";
        public override int MinOperandCount => 2;
        public override int MaxOperandCount => 2;
        public override bool Symbolic => false;

        public override object EvalValue(Func<string, object> context)
        {
            var operands = GetOperands(context);
            var operand1 = operands[0].ToString().Trim('[', ']');
            var operand2 = operands[1].ToString().Trim('[', ']');

            var operand1List = operand1.Split(',').Select(s => s.Trim()).ToList();
            var operand2List = operand2.Split(',').Select(s => s.Trim()).ToList();

            return operand1List.All(item => !operand2List.Contains(item));
        }
    }
}