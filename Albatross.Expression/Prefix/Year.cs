using Albatross.Expression.Nodes;
using System.Collections.Generic;


namespace Albatross.Expression.Prefix {
	/// <summary>
	/// Prefix expression that extracts the year component from a DateTime value.
	/// Returns an integer representing the year.
	/// </summary>
	public class Year : PrefixExpression {
		/// <summary>
		/// Initializes a new instance of the Year class with name "Year" and exactly one parameter.
		/// </summary>
		public Year() : base("Year", 1, 1) { }

		/// <summary>
		/// Extracts the year component from the provided DateTime operand.
		/// </summary>
		/// <param name="operands">List containing exactly one operand that can be converted to DateTime.</param>
		/// <returns>An integer representing the year (e.g., 2024).</returns>
		/// <exception cref="System.FormatException">Thrown when the operand cannot be converted to DateTime.</exception>
		protected override object Run(List<object> operands) 
			=> operands[0].ConvertToDateTime().Year;
	}
}
