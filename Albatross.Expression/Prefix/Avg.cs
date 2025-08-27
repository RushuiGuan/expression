using Albatross.Expression.Nodes;
using System.Collections.Generic;
using System.Linq;

namespace Albatross.Expression.Prefix {
	/// <summary>
	/// Prefix expression that calculates the arithmetic average of multiple numeric operands.
	/// Takes zero or more parameters and returns their mean value.
	/// </summary>
	public class Avg : PrefixExpression {
		/// <summary>
		/// Initializes a new instance of the Avg class with name "Avg" and variable parameter count (minimum 0).
		/// </summary>
		public Avg() : base("Avg", 0, int.MaxValue) { }

		/// <summary>
		/// Calculates the arithmetic average of all numeric operands.
		/// Each operand is converted to double, summed, and divided by the count. Returns NaN if no operands provided.
		/// </summary>
		/// <param name="items">List containing zero or more numeric operands to average.</param>
		/// <returns>The arithmetic mean of all operands as a double, or NaN for empty lists.</returns>
		/// <exception cref="FormatException">Thrown when any operand cannot be converted to a numeric value.</exception>
		/// <exception cref="DivideByZeroException">May return NaN when dividing by zero operands.</exception>
		protected override object Run(List<object> items) {
			return items.Sum(x => x.ConvertToDouble()) / items.Count;
		}
	}
}