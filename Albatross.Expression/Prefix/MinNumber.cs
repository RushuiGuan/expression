using System;
using System.Collections.Generic;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Prefix {
	/// <summary>
	/// Prefix expression that finds the minimum value among multiple numeric operands.
	/// Takes zero or more parameters and returns the smallest numeric value, or MaxValue if no operands.
	/// </summary>
	public class MinNumber : PrefixExpression {
		/// <summary>
		/// Initializes a new instance of the MinNumber class with name "Min" and variable parameter count (minimum 0).
		/// </summary>
		public MinNumber() : base("Min", 0, int.MaxValue) { }

		/// <summary>
		/// Finds and returns the minimum numeric value from all operands.
		/// Each operand is converted to double before comparison. Returns MaxValue if no operands provided.
		/// </summary>
		/// <param name="operands">List containing zero or more numeric operands to compare.</param>
		/// <returns>The minimum numeric value as a double, or double.MaxValue if no operands.</returns>
		/// <exception cref="FormatException">Thrown when any operand cannot be converted to a numeric value.</exception>
		protected override object Run(List<object> operands) {
			var current = double.MaxValue;
			foreach (var value in operands) {
				var item = value.ConvertToDouble();
				if (item < current) {
					current = item;
				}
			}
			return current;
		}
	}
}
