using Albatross.Expression.Documentation;
using Albatross.Expression.Documentation.Attributes;
using Albatross.Expression.Tokens;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace Albatross.Expression.Functions.Text
{
    [FunctionDoc(Group.Text, "{token}(@text)",
        @"
### Transforms any string into json formatted string.
#### Inputs:
- text: Any

#### Outputs:
- String

#### References:
- [{token}](https://help.workiom.com/article/formula#{token})
        ",
        @"
{token}(""OK 👍"")
        "
    )]
    [ParserOperation]
    public class ToJsonFormat : PrefixOperationToken
    {
        public override string Name { get { return "ToJsonFormat"; } }
        public override int MinOperandCount { get { return 1; } }
        public override int MaxOperandCount { get { return 1; } }
        public override bool Symbolic { get { return false; } }

        public override object EvalValue(Func<string, object> context)
        {
            object value = Operands.First().EvalValue(context);
            if (ExpressionMode.IsValidationMode)
                return value?.ToString();

            return ObjectToJsonFormat(value);
        }

        private string ObjectToJsonFormat(object value)
        {
            var jsonSerializerSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                StringEscapeHandling = StringEscapeHandling.EscapeNonAscii,
            };

            var json = JsonConvert.SerializeObject(value, jsonSerializerSettings);

            return json;
        }
    }
}
