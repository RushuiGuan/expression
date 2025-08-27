using System.Collections.Generic;
using System.Text;


namespace Albatross.Expression.Prefix {
	/// <summary>
	/// Prefix expression that concatenates multiple operands into a single string.
	/// Takes one or more parameters and joins them together without separators.
	/// </summary>
	public class Concat : PrefixExpression {
		/// <summary>
		/// Initializes a new instance of the Concat class with name "Concat" and variable parameter count (minimum 1).
		/// </summary>
		public Concat() : base("Concat", 1, int.MaxValue) { }

		/// <summary>
		/// Concatenates all operands into a single string by converting each to string and joining without separators.
		/// </summary>
		/// <param name="operands">List containing one or more operands to concatenate.</param>
		/// <returns>A string containing all operands concatenated together.</returns>
		protected override object Run(List<object> operands) {
			var sb = new StringBuilder();
			foreach(var operand in operands) {
				sb.Append(operand.ConvertToString());
			}
			return sb.ToString();
		}
	}
}