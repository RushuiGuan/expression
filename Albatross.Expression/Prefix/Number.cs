using System;
using System.Collections.Generic;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Prefix {
	/// <summary>
	/// Prefix expression that converts an operand to a numeric (double) value.
	/// Takes exactly one parameter and performs type conversion to double.
	/// </summary>
	public class Number : PrefixExpression {
		/// <summary>
		/// Initializes a new instance of the Number class with name "Number" and exactly one parameter.
		/// </summary>
		public Number() : base("Number", 1, 1) { }

		/// <summary>
		/// Converts the provided operand to a double value using the framework's conversion methods.
		/// Supports conversion from strings, numeric types, and JSON elements.
		/// </summary>
		/// <param name="operands">List containing exactly one operand to convert to numeric value.</param>
		/// <returns>The numeric representation of the operand as a double.</returns>
		/// <exception cref="FormatException">Thrown when the operand cannot be converted to a numeric value.</exception>
		protected override object Run(List<object> operands) {
			return operands[0].ConvertToDouble();
		}
	}
}
