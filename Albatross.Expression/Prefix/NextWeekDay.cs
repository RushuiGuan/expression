using Albatross.Dates;
using Albatross.Expression.Nodes;
using System.Collections.Generic;


namespace Albatross.Expression.Prefix {
	/// <summary>
	/// Prefix expression that finds the next weekday (Monday-Friday) from a given date.
	/// Takes 1-2 parameters: the starting date and optional number of weekdays to advance (defaults to 1).
	/// </summary>
	public class NextWeekDay : PrefixExpression {
		/// <summary>
		/// Initializes a new instance of the NextWeekDay class with name "NextWeekDay" and 1-2 parameters.
		/// </summary>
		public NextWeekDay() : base("NextWeekDay", 1, 2) { }

		/// <summary>
		/// Finds the next weekday by advancing the specified number of weekdays from the given date.
		/// Skips weekends (Saturday and Sunday) and returns the next business day.
		/// </summary>
		/// <param name="operands">List containing 1-2 operands: starting date and optional weekday count (defaults to 1).</param>
		/// <returns>A DateTime representing the next weekday after advancing the specified count.</returns>
		/// <exception cref="System.FormatException">Thrown when operands cannot be converted to appropriate types.</exception>
		protected override object Run(List<object> operands) {
			var value = operands[0].ConvertToDateTime();
			var count = 1;
			if (this.Operands.Count == 2) {
				count = operands[1].ConvertToInt();
			}
			return value.NextWeekday(count);
		}
	}
}
