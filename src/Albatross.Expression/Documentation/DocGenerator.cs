using Albatross.Expression.Documentation.Attributes;
using Albatross.Expression.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Albatross.Expression.Documentation
{
    public static class DocGenerator
    {
        public static IList<DocItem> Generate()
        {
            var lst = new List<DocItem>();

            var types = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(x => typeof(IToken).IsAssignableFrom(x) && !x.IsAbstract)
            ;

            foreach (var type in types)
            {
                var docAttribute = type.GetCustomAttribute<DocAttribute>();
                if (docAttribute != null)
                {
                    var instance = (IToken)Activator.CreateInstance(type);
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
            }

            return lst;
        }
    }
}
