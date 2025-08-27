using System.Collections.Generic;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Prefix {
	/// <summary>
	/// Prefix expression that converts a string to lowercase using invariant culture.
	/// </summary>
	public class Lower : PrefixExpression {
		/// <summary>
		/// Initializes a new instance of the Lower class with name "Lower" and exactly one parameter.
		/// </summary>
		public Lower() : base("Lower", 1, 1) { }

		/// <summary>
		/// Converts the provided string operand to lowercase using invariant culture rules.
		/// </summary>
		/// <param name="operands">List containing exactly one operand that can be converted to string.</param>
		/// <returns>The lowercase representation of the input string using invariant culture.</returns>
		protected override object Run(List<object> operands)
			=> operands[0].ConvertToString().ToLowerInvariant();
	}
}