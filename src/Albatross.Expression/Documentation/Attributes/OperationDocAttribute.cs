using System;

namespace Albatross.Expression.Documentation.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class OperationDocAttribute : DocAttribute
    {
        public OperationDocAttribute(Group group, string expression) : base(group, expression)
        {
        }

        public OperationDocAttribute(Group group, string expression, string description) : base(group, expression, description)
        {
        }

        public OperationDocAttribute(Group group, string expression, string description, string example) : base(group, expression, description, example)
        {
        }
    }
}
