using Albatross.Expression.Documentation;
using Albatross.Expression.Documentation.Attributes;

namespace Albatross.Expression.Functions.Number
{
    [FunctionDoc(Group.Number, "{token}(@val)",
        @"
### Return number value of the passed string
#### Inputs:
- @val: Number as a string
#### Outputs:
- Double.

#### References:
- [{token}](https://help.workiom.com/article/formula#{token})
        ",
        @"
{token}('1')
        "
    )]
    [ParserOperation]
    public class ToNumber : Number
    {
        public override string Name { get { return "toNumber"; } }
    }
}
