using System;

namespace Albatross.Expression.Documentation.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class OperationDocAttribute : DocAttribute
    {
        public OperationDocAttribute(Group group, string signature) : base(group, signature)
        {
        }

        public OperationDocAttribute(Group group, string signature, string description) : base(group, signature, description)
        {
        }
    }
}
