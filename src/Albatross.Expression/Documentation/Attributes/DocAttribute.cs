using System;

namespace Albatross.Expression.Documentation.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public abstract class DocAttribute : Attribute
    {
        public DocAttribute(Group group, string signature) : this(group, signature, null)
        {
        }

        public DocAttribute(Group group, string signature, string description)
        {
            Group = group;
            Signature = signature;
            Description = description;
        }

        public Group Group { get; }

        public string Signature { get; private set; }

        public string Description { get; set; }

        public void ReplaceTokenWithName(string name)
        {
            var namePattern = "{token}";
            Signature = Signature.Replace(namePattern, name);
            Description = Description.Replace(namePattern, name);
        }
    }
}
