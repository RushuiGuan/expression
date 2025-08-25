using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Albatross.Expression.Nodes;


namespace Albatross.Expression.Prefix {
	/// <summary>
	/// The operation use Regex to capture a part of the input text.  It takes 3 parameters.
	/// parameter 1 (text): the text to be parsed
	/// parameter 2 (text): a regex pattern
	/// parameter 3 (integer): Captured group index.  If regex matches, return the specified captured group value.  The default value is
	/// 0 if not specified
	/// </summary>
	public class RegexCapture : PrefixExpression {
		public RegexCapture() : base("RegexCapture", 2, 3) { }

		public override object Run(List<object> operands) {
			string text = operands[0].ConvertToString();
			string pattern = operands.GetRequiredStringValue(1);
			int index = 0;
			if (this.Operands.Count > 2) {
				index = operands[2].ConvertToInt();
			}
			Regex regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
			var match = regex.Match(text);
			if (match.Success) {
				if (match.Groups.Count > index) {
					return match.Groups[index].Value;
				} else {
					throw new ArgumentException($"Regex pattern {pattern} doesn't have a capture group with the index of {index}");
				}
			} else {
				throw new ArgumentException($"Regex pattern {pattern} does not match the input text '{text}'");
			}
		}
	}
}
