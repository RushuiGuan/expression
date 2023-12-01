using Albatross.Expression.Documentation.Attributes;
using Albatross.Expression.Exceptions;
using Albatross.Expression.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Group = Albatross.Expression.Documentation.Group;

namespace Albatross.Expression.Operations
{
    [FunctionDoc(Group.Text, "{token}( )",
@"### Returns the number of words in a string.
#### Inputs:
- string: String
#### Outputs:
- Integer"
    )]
    [ParserOperation]
    public class WordCount : PrefixOperationToken
    {

        public override string Name { get { return "WordCount"; } }
        public override int MinOperandCount { get { return 1; } }
        public override int MaxOperandCount { get { return 1; } }
        public override bool Symbolic { get { return false; } }

        public override object EvalValue(Func<string, object> context)
        {
            List<object> list = GetOperands(context);

            object value = list[0];
            if (value == null)
            {
                return null;
            }
            else if (value is string)
            {
                return CountWords((string)value);
            }
            if (value is ICollection)
            {
                return Convert.ToDouble(((ICollection)value).Count);
            }
            else
            {
                throw new UnexpectedTypeException(value.GetType());
            }
        }

        private double CountWords(string text)
        {
            // Strip of markdown syntax
            var result = text.TryNormalizeText(out string normalizedText);

            if (result)
            {
                text = normalizedText;
            }

            // Define a regular expression pattern for matching words
            string pattern = @"\b\w+\b";

            // Use Regex.Matches to find all matches in the input text
            MatchCollection matches = Regex.Matches(text, pattern);

            // The Count property of MatchCollection gives the number of matches
            var wordCount = (double)matches.Count;

            return wordCount;
        }
    }
}
