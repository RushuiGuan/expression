using Albatross.Expression.Documentation;
using Albatross.Expression.Documentation.Attributes;

namespace Albatross.Expression.Functions.Number
{
    [FunctionDoc(Group.Number, "{token}( )",
@"### Return number value of the passed string
#### Inputs:
- @val: Number as a string
#### Outputs:
- Double."
    )]
    [ParserOperation]
    public class ToNumber : Number
    {
        public override string Name { get { return "toNumber"; } }
    }
}
