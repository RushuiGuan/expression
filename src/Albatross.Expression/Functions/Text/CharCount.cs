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
@"### Returns the number of characters in a string.
#### Inputs:
- string: String
#### Outputs:
- Integer"
    )]
    [ParserOperation]
    public class CharCount : PrefixOperationToken
    {

        public override string Name { get { return "CharCount"; } }
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
            else if (value is ICollection)
            {
                return Convert.ToDouble(((ICollection)value).Count);
            }
            if (value is string)
            {
                return CountChars((string)value);
            }
            else
            {
                throw new UnexpectedTypeException(value.GetType());
            }
        }

        private double CountChars(string text)
        {
            // Strip of markdown syntax
            var result = text.TryNormalizeText(out string normalizedText);

            if (result)
            {
                text = normalizedText;
            }

            // Define the pattern to match non-space characters
            string pattern = @"\S";

            // Use Regex.Matches to find all matches
            MatchCollection matches = Regex.Matches(text, pattern);

            // Count the number of matches
            var charCount = (double)matches.Count;

            return charCount;
        }
    }
}
