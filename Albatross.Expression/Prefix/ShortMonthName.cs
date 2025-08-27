using System;
using Albatross.Expression.Nodes;

using System.Globalization;
using System.Collections.Generic;

namespace Albatross.Expression.Prefix {
	/// <summary>
	/// Prefix expression that returns the abbreviated month name from a DateTime value.
	/// Uses the current culture's formatting to return the localized short month name.
	/// </summary>
	public class ShortMonthName : PrefixExpression {
		/// <summary>
		/// Initializes a new instance of the ShortMonthName class with name "ShortMonthName" and exactly one parameter.
		/// </summary>
		public ShortMonthName() : base("ShortMonthName", 1, 1) { }

		/// <summary>
		/// Returns the abbreviated month name from the provided DateTime operand using current culture formatting.
		/// For example, returns "Jan", "Feb", etc. in English or localized equivalents.
		/// </summary>
		/// <param name="operands">List containing exactly one operand that can be converted to DateTime.</param>
		/// <returns>A string containing the abbreviated month name in the current culture.</returns>
		/// <exception cref="FormatException">Thrown when the operand cannot be converted to DateTime.</exception>
		protected override object Run(List<object> operands) {
			var date = operands[0].ConvertToDateTime();
			return CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(date.Month);
		}
	}
}
