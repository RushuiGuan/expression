using Albatross.Expression.Documentation.Attributes;
using Albatross.Expression.Exceptions;
using Albatross.Expression.Tokens;
using System;
using System.Collections;
using System.Text;

namespace Albatross.Expression.Operations
{
    /// <summary>
    /// <para>Prefix operation that will take an input and C# format string and produced a formatted string</para>
    /// 
    /// </summary>
    [FunctionDoc(Documentation.Group.Text, "{token}(@p1,@p2,...)",
        @"
### Combines a values as one text
#### Inputs:
- set: Set of variables

#### Outputs:
- string.

#### References:
- [{token}](https://help.workiom.com/article/formula#{token})
        ",
        @"
{token}(Now(),""yyyy-MM-dd"")
        "
    )]
    [ParserOperation]
    public class Concat : PrefixOperationToken
    {

        public override string Name { get { return "Concat"; } }
        public override int MinOperandCount { get { return 0; } }
        public override int MaxOperandCount { get { return int.MaxValue; } }
        public override bool Symbolic { get { return false; } }


        public override object EvalValue(Func<string, object> context)
        {
            if (Operands.Count == 0) { return null; }

            IEnumerable items = GetParamsOperands(context, out var type);
            StringBuilder stringBuilder = new StringBuilder();

            try
            {
                foreach (var item in items)
                    stringBuilder.Append(item);
            }
            catch (InvalidCastException)
            {
                throw new UnexpectedTypeException();
            }

            return stringBuilder.ToString();
        }
    }
}
