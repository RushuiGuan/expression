using System;
using System.Linq;
using System.Text.RegularExpressions;
using Albatross.Expression.Exceptions;
using Albatross.Expression.Nodes;


namespace Albatross.Expression.Operations {
	/// <summary>
	/// The operation use Regex to capture a part of the input text.  It takes 3 parameters.
	/// parameter 1 (text): the text to be parsed
	/// parameter 2 (text): a regex pattern
	/// parameter 3 (integer): Captured group index.  If regex matches, return the specified captured group value.  The default value is
	/// 0 if not specified
	/// </summary>
	[ParserOperation]
	public class RegexCapture : PrefixExpression {

		public override string Name { get { return "RegexCapture"; } }
		public override int MinOperandCount { get { return 2; } }
		public override int MaxOperandCount { get { return 3; } }
		public override bool Symbolic { get { return false; } }

		public override object? Eval(Func<string, object> context) {
			var operands = GetOperands(context);
			string text = Convert.ToString(operands[0]);
			string pattern = Convert.ToString(operands[1]);
			int index = 0;
			if(operands.Count > 2) {
				index = Convert.ToInt32(operands[2]);
			}
			Regex regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
			var match = regex.Match(text);
			if(match.Success) {
				if(match.Groups.Count > index) {
					return match.Groups[index].Value;
				} else {
					throw new ArgumentException($"Regex pattern {pattern} doesn't have a capture group with the index of {index}");
				}
			} else {
				return null;
			}
		}
	}
}
