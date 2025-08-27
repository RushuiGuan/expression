using System;
using Albatross.Expression.Nodes;
using System.Collections.Generic;


namespace Albatross.Expression.Prefix {
	/// <summary>
	/// Prefix expression that extracts the day of the week from a DateTime value.
	/// Returns a numeric value representing the day (0=Sunday, 1=Monday, etc.).
	/// </summary>
	public class DayOfWeek : PrefixExpression {
		/// <summary>
		/// Initializes a new instance of the DayOfWeek class with name "DayOfWeek" and exactly one parameter.
		/// </summary>
		public DayOfWeek() : base("DayOfWeek", 1, 1) { }

		/// <summary>
		/// Extracts the day of the week from the provided DateTime operand.
		/// Converts the DayOfWeek enum value to a double (0=Sunday, 1=Monday, 2=Tuesday, etc.).
		/// </summary>
		/// <param name="operands">List containing exactly one operand that can be converted to DateTime.</param>
		/// <returns>A double representing the day of the week (0-6, where 0 is Sunday).</returns>
		/// <exception cref="FormatException">Thrown when the operand cannot be converted to DateTime.</exception>
		protected override object Run(List<object> operands) {
			var dateTime = operands[0].ConvertToDateTime();
			return Convert.ToDouble(dateTime.DayOfWeek);
		}
	}
}
