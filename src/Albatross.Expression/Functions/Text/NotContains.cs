using Albatross.Expression.Documentation.Attributes;
using Albatross.Expression.Exceptions;
using Albatross.Expression.Tokens;
using System;
using System.Linq;

namespace Albatross.Expression.Operations
{
    [FunctionDoc(Documentation.Group.Text, "{token}( , )",
        @"### Check if it does not contain a specific text
#### Inputs:
- set: text
#### Outputs:
- true or false."
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
                var operand1List = operand1.Split(',').Select(s => s.Trim()).ToList();
                var operand2List = operand2.Split(',').Select(s => s.Trim()).ToList();

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