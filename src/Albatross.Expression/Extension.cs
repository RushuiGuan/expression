using Albatross.Expression.Tokens;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Albatross.Expression
{
    public static class Extensions
    {
        public static bool ConvertToBoolean(this object obj)
        {
            if (obj != null)
            {
                if (obj is double)
                {
                    return (double)obj != 0;
                }
                else if (obj is bool)
                {
                    return (bool)obj;
                }
                else
                {
                    return true;
                }

            }
            else
            {
                return false;
            }
        }

        #region IExecutionContext

        public static void SetExpression<T>(this IExecutionContext<T> context, string name, string expression)
        {
            context.Set(new ContextValue() { Name = name, Value = expression, ContextType = ContextType.Expression, });
        }

        public static void SetExpression<T>(this IExecutionContext<T> context, string name, string expression,
            Type dataType)
        {
            context.Set(new ContextValue()
            { Name = name, Value = expression, ContextType = ContextType.Expression, DataType = dataType });
        }

        public static void SetValue<T>(this IExecutionContext<T> context, string name, object value)
        {
            context.Set(new ContextValue() { Name = name, Value = value, ContextType = ContextType.Value, });
        }

        public static object GetValue<T>(this IExecutionContext<T> context, string name, T input)
        {
            object data;
            if (context.TryGetValue(name, input, out data))
            {
                return data;
            }
            else
            {
                return null;
            }
        }

        public static ContextValue Set<T>(this IExecutionContext<T> context, string assignmentExpression)
        {
            ContextValue value = new ContextValue
            {
                ContextType = ContextType.Expression,
            };
            IToken token = context.Parser.VariableToken();
            int start = 0, next;
            if (token.Match(assignmentExpression, start, out next))
            {
                start = assignmentExpression.SkipSpace(start);
                value.Name = assignmentExpression.Substring(start, next - start);
                start = next;
                if (new AssignmentToken().Match(assignmentExpression, start, out next))
                {
                    value.Value = assignmentExpression.Substring(next);
                    context.Set(value);
                    return value;
                }
            }

            throw new Exceptions.TokenParsingException("Invalid assignment expression");
        }

        #endregion

        #region IToken

        public static bool IsVariable(this IToken token)
        {
            return token is IVariableToken;
        }

        /// <summary>
        /// Move find the next index that is not a space.  This method doesn't perform check of the starting index in any way.
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="start">The current index</param>
        /// <returns></returns>
        public static int SkipSpace(this string expression, int start)
        {
            while (expression.Length > start && char.IsWhiteSpace(expression[start]))
            {
                start++;
            }

            return start;
        }

        #endregion

        #region IParser

        public static IToken Compile(this IParser parser, string expression)
        {
            Queue<IToken> queue = parser.Tokenize(expression);
            Stack<IToken> stack = parser.BuildStack(queue);
            return parser.CreateTree(stack);
        }

        #endregion

        #region String

        public static bool TryNormalizeText(this string text, out string normalizedText)
        {
            // Replace All \n to into \\n so it can be seen as a new line
            text = text.Replace("\\n", "\n");

            // Regular expression pattern to check for basic Markdown elements
            string markdownPattern = @"^(\s*#+\s+|\*|\d+\.\s+|\-|\+|\[\!\[.*\]\(.*\)\]\(.*\)|\[\w+.*\]:\s*http[s]?://\S+|```[\s\S]+?```|\|.*\|.*\|)|(!\[[^\]]*\]\([^\)]*\)|\[[^\]]*\]\([^\)]*\)|\*\*.*\*\*|__.*__|\*.*\*|_.*_|`[^`]*`|\[.*\]\(.*\)|<.*>)$";

            Regex regex = new Regex(markdownPattern, RegexOptions.Multiline);

            if (!regex.IsMatch(text))
            {
                normalizedText = null;
                return false;
            }

            // Convert it to Html and then to plain text
            text = ConvertHtmlToPlainText(CommonMark.CommonMarkConverter.Convert(text));

            // Remove all markdown tags
            text = Regex.Replace(text, "\n=+", ""); // Headers    
            text = Regex.Replace(text, @"\*\*(.*?)\*\*", "$1", RegexOptions.Multiline); // Remove bold tags
            text = Regex.Replace(text, @"\*(.*?)\*", "$1", RegexOptions.Multiline); // Remove italic tags
            text = Regex.Replace(text, @"~~(.*?)~~", "$1", RegexOptions.Multiline); // Remove strikethrough tags
            text = Regex.Replace(text, @"`(.*?)`", "$1", RegexOptions.Multiline); // Remove inline code tags
            text = Regex.Replace(text, @"\[(.*?)\]\(.*?\)", "$1", RegexOptions.Multiline); // Remove link tags
            text = Regex.Replace(text, @"!\[(.*?)\]\(.*?\)", "$1", RegexOptions.Multiline); // Remove image tags
            text = Regex.Replace(text, @"^#+\s+", "", RegexOptions.Multiline); // Remove heading tags
            text = Regex.Replace(text, @"\n[*-]\s+", ""); // Remove list item tags
            text = Regex.Replace(text, @"\n\d+\.\s+", ""); // Remove ordered list item tags
            text = Regex.Replace(text, @"^-{3,}", "", RegexOptions.Multiline); // Remove horizontal rule tags
            text = Regex.Replace(text, @"`{3}[\s\S]*?`{3}", "", RegexOptions.Multiline); // Remove code block tags
            text = Regex.Replace(text, @"\|.*?\|(\n\|.*?\|)*", ""); // Remove table tags

            // Replace escape sequences with white space
            text = Regex.Replace(text, @"\\[abfnrt\'\""\0]|\\x[0-9a-fA-F]{2}|\\u[0-9a-fA-F]{4}",
                " ");

            // Add regex to remove escape sequences
            text = Regex.Replace(text, @"\\[nt\""']+", "");

            normalizedText = text.Trim(); // Trim leading and trailing spaces

            return true;
        }

        #endregion

        #region Utilities

        private static string ConvertHtmlToPlainText(string html)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            // Use HtmlAgilityPack to extract text from HTML
            return doc.DocumentNode.InnerText;
        }

        #endregion
    }
}
