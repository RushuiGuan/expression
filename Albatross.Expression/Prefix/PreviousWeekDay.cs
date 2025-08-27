using System.Collections.Generic;
using Albatross.Dates;


namespace Albatross.Expression.Prefix {
	/// <summary>
	/// Prefix expression that finds the previous weekday (Monday-Friday) from a given date.
	/// Takes 1-2 parameters: the starting date and optional number of weekdays to go back (defaults to 1).
	/// </summary>
	public class PreviousWeekDay : PrefixExpression {
		/// <summary>
		/// Initializes a new instance of the PreviousWeekDay class with name "PreviousWeekDay" and 1-2 parameters.
		/// </summary>
		public PreviousWeekDay() : base("PreviousWeekDay", 1, 2) { }

		/// <summary>
		/// Finds the previous weekday by going back the specified number of weekdays from the given date.
		/// Skips weekends (Saturday and Sunday) and returns the previous business day.
		/// </summary>
		/// <param name="operands">List containing 1-2 operands: starting date and optional weekday count (defaults to 1).</param>
		/// <returns>A DateTime representing the previous weekday after going back the specified count.</returns>
		/// <exception cref="FormatException">Thrown when operands cannot be converted to appropriate types.</exception>
		protected override object Run(List<object> operands) {
			var date = operands[0].ConvertToDateTime();
			var count = 1;
			if (this.Operands.Count > 1) {
				count = operands[1].ConvertToInt();
			}
			return date.PreviousWeekday(count);
		}
	}
}
