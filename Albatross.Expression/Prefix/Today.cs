using System;
using Albatross.Expression.Nodes;
using System.Collections.Generic;

namespace Albatross.Expression.Prefix {
	/// <summary>
	/// Prefix expression that returns the current date at midnight (start of day).
	/// Takes no parameters and returns DateTime.Today.
	/// </summary>
	public class Today : PrefixExpression {
		/// <summary>
		/// Initializes a new instance of the Today class with name "Today" and no parameters.
		/// </summary>
		public Today() : base("Today", 0, 0) { }

		/// <summary>
		/// Returns the current date at midnight (00:00:00).
		/// </summary>
		/// <param name="operands">Empty list (no operands required).</param>
		/// <returns>The current date with time set to midnight.</returns>
		protected override object Run(List<object> operands) => DateTime.Today;
	}
}