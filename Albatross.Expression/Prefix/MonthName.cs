using Albatross.Expression.Nodes;
using System.Globalization;
using System.Collections.Generic;

namespace Albatross.Expression.Prefix {
	/// <summary>
	/// Prefix expression that returns the full month name from a DateTime value.
	/// Uses the current culture's formatting to return the localized month name.
	/// </summary>
	public class MonthName : PrefixExpression {
		/// <summary>
		/// Initializes a new instance of the MonthName class with name "MonthName" and exactly one parameter.
		/// </summary>
		public MonthName() : base("MonthName", 1, 1) { }

		/// <summary>
		/// Returns the full month name from the provided DateTime operand using current culture formatting.
		/// For example, returns "January", "February", etc. in English or localized equivalents.
		/// </summary>
		/// <param name="operands">List containing exactly one operand that can be converted to DateTime.</param>
		/// <returns>A string containing the full month name in the current culture.</returns>
		/// <exception cref="System.FormatException">Thrown when the operand cannot be converted to DateTime.</exception>
		protected override object Run(List<object> operands) {
			var value = operands[0].ConvertToDateTime();
			return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(value.Month);
		}
	}
}