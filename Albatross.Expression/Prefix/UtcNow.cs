using System;
using Albatross.Expression.Nodes;
using System.Collections.Generic;

namespace Albatross.Expression.Prefix {
	/// <summary>
	/// Prefix expression that returns the current Coordinated Universal Time (UTC).
	/// Takes no parameters and returns DateTime.UtcNow.
	/// </summary>
	public class UtcNow : PrefixExpression {
		/// <summary>
		/// Initializes a new instance of the UtcNow class with name "UtcNow" and no parameters.
		/// </summary>
		public UtcNow() : base("UtcNow", 0, 0) { }
		
		/// <summary>
		/// Returns the current date and time in Coordinated Universal Time (UTC).
		/// </summary>
		/// <param name="operands">Empty list (no operands required).</param>
		/// <returns>The current UTC DateTime value.</returns>
		protected override object Run(List<object> operands) => System.DateTime.UtcNow;
	}
}
