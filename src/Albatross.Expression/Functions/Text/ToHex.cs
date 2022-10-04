using Albatross.Expression.Documentation;
using Albatross.Expression.Documentation.Attributes;
using Albatross.Expression.Tokens;
using System;
using System.Linq;
using System.Text;

namespace Albatross.Expression.Functions.Text
{
    [FunctionDoc(Group.Text, "{token}(@text)",
        @"
### Transforms any string into hex formatted string.
#### Inputs:
- text: Any

#### Outputs:
- String

#### References:
- [{token}](https://help.workiom.com/article/formula#{token})
        ",
        @"
{token}(""Text"")
        "
    )]
    [ParserOperation]
    public class ToHex : PrefixOperationToken
    {
        public override string Name { get { return "ToHex"; } }
        public override int MinOperandCount { get { return 1; } }
        public override int MaxOperandCount { get { return 1; } }
        public override bool Symbolic { get { return false; } }

        public override object EvalValue(Func<string, object> context)
        {
            object value = Operands.First().EvalValue(context);
            if (ExpressionMode.IsValidationMode)
                return value?.ToString();

            return StringToHex(value?.ToString());
        }

        private string StringToHex(string value)
        {
            var stringBuilder = new StringBuilder();
            foreach (char character in value)
            {
                stringBuilder.Append(Convert.ToString(character, 16).PadLeft(4, '0'));
            }

            return stringBuilder.ToString();            
        }
    }
}
