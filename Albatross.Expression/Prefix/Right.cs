using System;
using System.Collections.Generic;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Prefix {
	/// <summary>
	/// Prefix expression that extracts a specified number of characters from the right side of a string.
	/// Takes two parameters: the source string and the number of characters to extract.
	/// </summary>
	public class Right : PrefixExpression {
		/// <summary>
		/// Initializes a new instance of the Right class with name "Right" and exactly two parameters.
		/// </summary>
		public Right() : base("Right", 2, 2) { }
		
		/// <summary>
		/// Extracts the specified number of characters from the right side of the input string.
		/// If the requested count is greater than the string length, returns the entire string.
		/// </summary>
		/// <param name="operands">List containing exactly two operands: source string and character count.</param>
		/// <returns>A string containing the rightmost characters, or the entire string if count exceeds length.</returns>
		/// <exception cref="Exceptions.OperandException">Thrown when the character count is negative.</exception>
		/// <exception cref="FormatException">Thrown when operands cannot be converted to string and integer respectively.</exception>
		protected override object Run(List<object> operands) {
			var text = operands[0].ConvertToString();
			var count = operands[1].ConvertToInt();
			if (count < 0) {
				throw new Exceptions.OperandException("Right operation expects a positive number for the second parameter");
			}
			if (count > text.Length) {
				return text;
			} else {
				return text.Substring(text.Length - count, count);
			}
		}
	}
}
