using System;

namespace Albatross.Expression.Documentation.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class FunctionDocAttribute : DocAttribute
    {
        public FunctionDocAttribute(Group group, string expression) : base(group, expression)
        {
        }

        public FunctionDocAttribute(Group group, string expression, string description) : base(group, expression, description)
        {
        }

        public FunctionDocAttribute(Group group, string expression, string description, string example) : base(group, expression, description, example)
        {
        }
    }
}
