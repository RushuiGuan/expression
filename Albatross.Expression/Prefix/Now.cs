using System;
using System.Collections.Generic;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Prefix {
	/// <summary>
	/// Prefix expression that returns the current local date and time.
	/// Takes no parameters and returns DateTime.Now.
	/// </summary>
	public class Now : PrefixExpression {
		/// <summary>
		/// Initializes a new instance of the Now class with name "Now" and no parameters.
		/// </summary>
		public Now() : base("Now", 0, 0) { }

		/// <summary>
		/// Returns the current local date and time.
		/// </summary>
		/// <param name="operands">Empty list (no operands required).</param>
		/// <returns>The current local DateTime value.</returns>
		protected override object Run(List<object> operands) {
			return System.DateTime.Now;
		}
	}
}
