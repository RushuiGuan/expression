using System;
using System.Linq;
using Albatross.Expression.Documentation.Attributes;
using Albatross.Expression.Tokens;

namespace Albatross.Expression.Functions.Text
{
    [FunctionDoc(Documentation.Group.Text, "{token}( , )",
        "### Check if operand1 is not contained within operand2\n"+
        "#### Inputs:\n"+
        "- operand1: a array of values or a single value to be checked\n"+
        "- operand2: a array of values or a single value\n"+
        "#### Outputs:\n"+
        "- false if operand1 is included in operand2, true otherwise."
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

            var operand1List = operand1.Split(',').Select(s => s.Trim()).ToArray();
            var operand2List = operand2.Split(',').Select(s => s.Trim()).ToArray();

            return operand1List.All(item => !operand2List.Contains(item));
        }
    }
}