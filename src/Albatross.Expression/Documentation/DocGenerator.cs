using Albatross.Expression.Documentation.Attributes;
using System.Collections.Generic;
using System.Reflection;

namespace Albatross.Expression.Documentation
{
    public static class DocGenerator
    {
        public static IList<DocItem> Generate()
        {
            var lst = new List<DocItem>();

            var tokens = new Factory().Operations;

            foreach (var token in tokens)
            {
                var type = token.Key;
                var instance = token.Value;

                var docAttribute = type.GetCustomAttribute<DocAttribute>();
                if (docAttribute != null)
                {
                    var isFunction = docAttribute is FunctionDocAttribute;
                    docAttribute.ReplaceTokenWithName(instance.Name);

                    lst.Add(new DocItem
                    {
                        Name = instance.Name,
                        Example = docAttribute.Example,
                        Expression = docAttribute.Expression,
                        Group = docAttribute.Group.ToString(),
                        Description = docAttribute.Description,
                        Type = (isFunction ? Type.Function : Type.Operation).ToString(),
                    });
                }
                else
                {
                    lst.Add(new DocItem
                    {
                        Name = instance.Name
                    });
                }
            }

            return lst;
        }
    }
}
