using System;

namespace Albatross.Expression.Documentation.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public abstract class DocAttribute : Attribute
    {
        public DocAttribute(Group group, string expression) : this(group, expression, null)
        {
        }

        public DocAttribute(Group group, string expression, string description) : this(group, expression, description, null)
        {
        }

        public DocAttribute(Group group, string expression, string description, string example)
        {
            Group = group;
            Example = example;
            Expression = expression;
            Description = description;
        }

        public Group Group { get; }

        public string Expression { get; private set; }

        public string Description { get; private set; }

        public string Example { get; private set; }

        public void ReplaceTokenWithName(string name)
        {
            var namePattern = "{token}";
            Example = Example.Replace(namePattern, name);
            Expression = Expression.Replace(namePattern, name);
            Description = Description.Replace(namePattern, name);
        }
    }
}
