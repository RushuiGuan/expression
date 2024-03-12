using Albatross.Expression.Documentation.Attributes;
using Albatross.Expression.Exceptions;
using Albatross.Expression.Tokens;
using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace Albatross.Expression.Operations
{
    /// <summary>
    /// <para>Prefix operation that will take an input and C# format string and produced a formatted string</para>
    /// 
    /// </summary>
    [FunctionDoc(Documentation.Group.Text, "{token}( , )",
        @"### Check if it contains a specific text
#### Inputs:
- set: text
#### Outputs:
- true or false."
    )]
    [ParserOperation]
    public class Contains : PrefixOperationToken
    {

        public override string Name => "Contains";
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

                foreach (var item in operand2List)
                {
                    if (!operand1List.Contains(item)) 
                        return false;
                }
            }
            else
            {
                if (!operand1.Contains(operand2))
                    return false;
            }

            return true;
        }
    }
}