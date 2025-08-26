using System;
using Albatross.Expression.Nodes;

namespace Albatross.Expression.Infix {
	/// <summary>
	/// Represents the addition operator that adds two numeric values.
	/// </summary>
	public class Plus : InfixExpression {
		/// <summary>
		/// Initializes a new instance of the <see cref="Plus"/> class.
		/// </summary>
		public Plus() : base("+", 100) { }

		protected override object Run(object left, object right) {
			return left.ConvertToDouble() + right.ConvertToDouble();
		}
	}
}
