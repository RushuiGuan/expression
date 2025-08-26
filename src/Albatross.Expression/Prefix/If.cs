using System.Collections.Generic;


namespace Albatross.Expression.Prefix {
	/// <summary>
	/// Represents the conditional If function that returns different values based on a boolean condition.
	/// Takes three operands: condition, value if true, value if false.
	/// </summary>
	public class If : PrefixExpression {
		/// <summary>
		/// Initializes a new instance of the <see cref="If"/> class.
		/// </summary>
		public If() : base("If", 3, 3) { }


		protected override object Run(List<object> operands) {
			var condition = operands[0].ConvertToBoolean();
			if (condition) {
				return operands[1];
			} else {
				return operands[2];
			}
		}
	}
}