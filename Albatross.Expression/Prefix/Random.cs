using System.Collections.Generic;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Prefix {
	/// <summary>
	/// Prefix expression that generates a random integer within a specified range.
	/// Takes two parameters: minimum (inclusive) and maximum (exclusive) values.
	/// </summary>
	public class Random : PrefixExpression {
		/// <summary>
		/// Initializes a new instance of the Random class with name "Random" and exactly two parameters.
		/// </summary>
		public Random() : base("Random", 2, 2) { }

		/// <summary>
		/// Generates a random integer between the minimum (inclusive) and maximum (exclusive) values.
		/// Uses the shared Random instance for thread safety.
		/// </summary>
		/// <param name="operands">List containing exactly two operands: minimum and maximum integer values.</param>
		/// <returns>A random integer greater than or equal to min and less than max.</returns>
		/// <exception cref="System.FormatException">Thrown when operands cannot be converted to integers.</exception>
		/// <exception cref="ArgumentOutOfRangeException">Thrown when min is greater than max.</exception>
		protected override object Run(List<object> operands) {
			var min = operands[0].ConvertToInt();
			var max = operands[1].ConvertToInt();
			return System.Random.Shared.Next(min, max);
		}
	}
}
