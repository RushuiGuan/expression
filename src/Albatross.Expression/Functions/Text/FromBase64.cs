using Albatross.Expression.Documentation;
using Albatross.Expression.Documentation.Attributes;
using Albatross.Expression.Tokens;
using System;
using System.Linq;

namespace Albatross.Expression.Functions.Text
{
    [FunctionDoc(Group.Text, "{token}(@text)",
        @"
### Transforms any base64 string into an object.
#### Inputs:
- text: Any

#### Outputs:
- Object

#### References:
- [{token}](https://help.workiom.com/article/formula#{token})
        ",
        @"
{token}(""MQ=="")
        "
    )]
    [ParserOperation]
    public class FromBase64 : PrefixOperationToken
    {
        public override string Name { get { return "FromBase64"; } }
        public override int MinOperandCount { get { return 1; } }
        public override int MaxOperandCount { get { return 1; } }
        public override bool Symbolic { get { return false; } }

        public override object EvalValue(Func<string, object> context)
        {
            object value = Operands.First().EvalValue(context);
            if (ExpressionMode.IsValidationMode)
                return value?.ToString();

            return Base64Decode(value?.ToString());
        }

        private string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            var value = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);

            return value;
        }
    }
}
