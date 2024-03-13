using Albatross.Expression.Documentation.Attributes;
using Albatross.Expression.Exceptions;
using Albatross.Expression.Tokens;
using System;
using System.Linq;

namespace Albatross.Expression.Operations
{
    [FunctionDoc(Documentation.Group.Text, "{token}( , )",
        "### Check if operand2 is not contained within operand1\n"+
        "#### Inputs:\n"+
        "- operand1: a array of values or a single value\n"+
        "- operand2: a array of values or a value to be checked\n"+
        "#### Outputs:\n"+
        "- true if operand2 is included in operand1, false otherwise."
    )]
    [ParserOperation]
    public class NotContains : PrefixOperationToken
    {
        public override string Name => "NotContains";
        public override int MinOperandCount => 2;
        public override int MaxOperandCount => 2;
        public override bool Symbolic => false;

        public override object EvalValue(Func<string, object> context)
        {
            var operands = GetOperands(context);
            var operand1 = operands[0].ToString().Trim('[', ']');
            var operand2 = operands[1].ToString().Trim('[', ']');

            if (operand1.Contains(",") || operand2.Contains(","))
            {
                var operand1List = operand1.Split(',').Select(s => s.Trim()).ToArray();
                var operand2List = operand2.Split(',').Select(s => s.Trim()).ToArray();

                if (operand2List.Any(item => operand1List.Contains(item))) 
                    return false;
            }   
            else
            {
                if (operand1.Contains(operand2)) 
                    return false;
            }

            return true;
        }
    }
}