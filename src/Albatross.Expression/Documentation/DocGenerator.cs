using Albatross.Expression.Documentation.Attributes;
using System;
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
                var references = @"#### References:
- [{token}](https://help.workiom.com/article/formula#{token})";

                if (docAttribute != null)
                {
                    var isFunction = docAttribute is FunctionDocAttribute;
                    docAttribute.Description = $@"{docAttribute.Description}{Environment.NewLine}{references}";
                    docAttribute.ReplaceTokenWithName(instance.Name);

                    lst.Add(new DocItem
                    {
                        Token = instance.Name,
                        Signature = docAttribute.Signature,
                        Group = docAttribute.Group.ToString(),
                        Description = docAttribute.Description,
                        Type = (isFunction ? Type.Function : Type.Operation).ToString(),
                    });
                }
                else
                {
                    lst.Add(new DocItem
                    {
                        Token = instance.Name,
                        Signature = instance.Name,
                        Description = references
                    });
                }
            }

            return lst;
        }
    }
}
