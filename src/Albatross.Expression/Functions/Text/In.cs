using System;
using System.Linq;
using Albatross.Expression.Documentation.Attributes;
using Albatross.Expression.Tokens;

namespace Albatross.Expression.Functions.Text
{
    [FunctionDoc(Documentation.Group.Text, "{token}( , )",
    "### Check if operand2 is contained within operand1\n"+
    "#### Inputs:\n"+
    "- operand1: a array of values or a single value\n"+
    "- operand2: a array of values or a value to be checked\n"+
    "#### Outputs:\n"+
    "- true if operand2 is included in operand1, false otherwise."
    )]
    [ParserOperation]
    public class In : PrefixOperationToken
    {
        public override string Name => "In";
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
            
            return operand1List.All(val => operand2List.Contains(val));
        }
    }
}