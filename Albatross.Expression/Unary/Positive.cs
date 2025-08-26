using System;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Unary {
	/// <summary>
	/// Represents the unary plus operator that explicitly indicates a positive number.
	/// </summary>
	public class Positive : UnaryExpression {
		/// <summary>
		/// Initializes a new instance of the <see cref="Positive"/> class.
		/// </summary>
		public Positive() : base("+", 250) { }
		protected override object Run(object operand) {
			return operand.ConvertToDouble();
		}
	}
}
