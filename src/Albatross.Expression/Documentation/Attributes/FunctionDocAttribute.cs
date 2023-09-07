using System;

namespace Albatross.Expression.Documentation.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class FunctionDocAttribute : DocAttribute
    {
        public FunctionDocAttribute(Group group, string signature) : base(group, signature)
        {
        }

        public FunctionDocAttribute(Group group, string signature, string description) : base(group, signature, description)
        {
        }
    }
}
