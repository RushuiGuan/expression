using System.Collections.Generic;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Prefix {
	/// <summary>
	/// Prefix expression that converts an operand to its string representation.
	/// Takes exactly one parameter and performs type conversion to string.
	/// </summary>
	public class Text : PrefixExpression {
		/// <summary>
		/// Initializes a new instance of the Text class with name "Text" and exactly one parameter.
		/// </summary>
		public Text() : base("Text", 1, 1) { }

		/// <summary>
		/// Converts the provided operand to a string value using the framework's conversion methods.
		/// Handles various types including JsonElement and provides proper string representations.
		/// </summary>
		/// <param name="operands">List containing exactly one operand to convert to string.</param>
		/// <returns>The string representation of the operand, or empty string if operand is null.</returns>
		protected override object Run(List<object> operands) 
			=>  operands[0].ConvertToString();
	}
}
