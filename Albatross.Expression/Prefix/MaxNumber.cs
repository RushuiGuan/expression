using System;
using Albatross.Expression.Nodes;
using System.Collections;
using System.Collections.Generic;

namespace Albatross.Expression.Prefix {
	/// <summary>
	/// Prefix expression that finds the maximum value among multiple numeric operands.
	/// Takes one or more parameters and returns the largest numeric value.
	/// </summary>
	public class MaxNumber : PrefixExpression {
		/// <summary>
		/// Initializes a new instance of the MaxNumber class with name "Max" and variable parameter count (minimum 1).
		/// </summary>
		public MaxNumber() : base("Max", 1, int.MaxValue) { }

		/// <summary>
		/// Finds and returns the maximum numeric value from all operands.
		/// Each operand is converted to double before comparison.
		/// </summary>
		/// <param name="list">List containing one or more numeric operands to compare.</param>
		/// <returns>The maximum numeric value as a double.</returns>
		/// <exception cref="FormatException">Thrown when any operand cannot be converted to a numeric value.</exception>
		protected override object Run(List<object> list) {
			var current = double.MinValue;
			foreach (var item in list) {
				var value = item.ConvertToDouble();
				if (value > current) {
					current = value;
				}
			}
			return current;
		}
	}
}
