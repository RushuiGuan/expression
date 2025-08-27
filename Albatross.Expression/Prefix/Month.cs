using System;
using System.Collections.Generic;
using Albatross.Expression.Nodes;


namespace Albatross.Expression.Prefix {
	/// <summary>
	/// Prefix expression that extracts the month component from a DateTime value.
	/// Returns an integer representing the month (1-12).
	/// </summary>
	public class Month : PrefixExpression {
		/// <summary>
		/// Initializes a new instance of the Month class with name "Month" and exactly one parameter.
		/// </summary>
		public Month() : base("Month", 1, 1) { }

		/// <summary>
		/// Extracts the month component from the provided DateTime operand.
		/// </summary>
		/// <param name="operands">List containing exactly one operand that can be converted to DateTime.</param>
		/// <returns>An integer representing the month (1 for January, 12 for December).</returns>
		/// <exception cref="FormatException">Thrown when the operand cannot be converted to DateTime.</exception>
		protected override object Run(List<object> operands) {
			return operands[0].ConvertToDateTime().Month;
		}
	}
}
