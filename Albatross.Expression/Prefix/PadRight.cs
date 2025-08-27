using System.Collections.Generic;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Prefix {
	/// <summary>
	/// Prefix expression that pads a string to a specified total length by adding characters to the right.
	/// Takes 2-3 parameters: source string, total width, and optional padding character (defaults to space).
	/// </summary>
	public class PadRight : PrefixExpression {
		/// <summary>
		/// The default padding character used when none is specified (space character).
		/// </summary>
		public const char DefaultPaddingCharacter = ' ';
		
		/// <summary>
		/// Initializes a new instance of the PadRight class with name "PadRight" and 2-3 parameters.
		/// </summary>
		public PadRight() : base("PadRight", 2, 3) { }
		
		/// <summary>
		/// Pads the input string to the specified total width by adding padding characters to the right.
		/// If the string is already longer than the target width, returns the original string unchanged.
		/// </summary>
		/// <param name="operands">List containing 2-3 operands: source string, target width, and optional padding character.</param>
		/// <returns>A string padded to the specified width with characters added to the right.</returns>
		/// <exception cref="FormatException">Thrown when operands cannot be converted to appropriate types.</exception>
		/// <exception cref="ArgumentOutOfRangeException">Thrown when the target width is negative.</exception>
		protected override object Run(List<object> operands) {
			var text = operands[0].ConvertToString();
			var count = operands[1].ConvertToInt();
			char paddingCharacter;
			if (this.Operands.Count > 2) {
				paddingCharacter = operands.GetRequiredStringValue(2)[0];
			} else {
				paddingCharacter = DefaultPaddingCharacter;
			}
			return text.PadRight(count, paddingCharacter);
		}
	}
}
