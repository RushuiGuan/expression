using System.Collections.Generic;

namespace Albatross.Expression.Prefix {
	/// <summary>
	/// Represents the logical NOT function that inverts a boolean value.
	/// </summary>
	public class Not : PrefixExpression {
		/// <summary>
		/// Initializes a new instance of the <see cref="Not"/> class.
		/// </summary>
		public Not() : base("Not", 1, 1) { }
		
		protected override object Run(List<object> operands) {
			return !operands[0].ConvertToBoolean();
		}
	}
}
