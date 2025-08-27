using Albatross.Expression.Nodes;
using System.Collections.Generic;

namespace Albatross.Expression.Prefix {
	/// <summary>
	/// Prefix expression that converts a string to uppercase using invariant culture.
	/// </summary>
	public class Upper : PrefixExpression {
		/// <summary>
		/// Initializes a new instance of the Upper class with name "Upper" and exactly one parameter.
		/// </summary>
		public Upper() : base("Upper", 1, 1) { }

		/// <summary>
		/// Converts the provided string operand to uppercase using invariant culture rules.
		/// </summary>
		/// <param name="operands">List containing exactly one operand that can be converted to string.</param>
		/// <returns>The uppercase representation of the input string using invariant culture.</returns>
		protected override object Run(List<object> operands) 
			=> operands[0].ConvertToString().ToUpperInvariant();
	}
}
