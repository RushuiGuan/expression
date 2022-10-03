using Albatross.Expression.Documentation;
using Albatross.Expression.Documentation.Attributes;
using Albatross.Expression.Tokens;
using System;
using System.Linq;

namespace Albatross.Expression.Functions.Text
{
    [FunctionDoc(Group.Text, "{token}(@object)",
        @"
### Transforms any object into base64 string.
#### Inputs:
- text: Any

#### Outputs:
- String

#### References:
- [{token}](https://help.workiom.com/article/formula#{token})
        ",
        @"
{token}(1)
        "
    )]
    [ParserOperation]
    public class ToBase64 : PrefixOperationToken
    {
        public override string Name { get { return "ToBase64"; } }
        public override int MinOperandCount { get { return 1; } }
        public override int MaxOperandCount { get { return 1; } }
        public override bool Symbolic { get { return false; } }

        public override object EvalValue(Func<string, object> context)
        {
            object value = Operands.First().EvalValue(context);
            if (ExpressionMode.IsValidationMode)
                return value?.ToString();

            return Base64Encode(value?.ToString());
        }

        private string Base64Encode(string val)
        {
            string encodedStr = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(val));

            return encodedStr;
        }
    }
}
