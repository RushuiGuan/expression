using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Nodes;
using System.Xml;

namespace Albatross.Expression.Infix {
	/// <summary>
	/// Infix expression that performs not-equal comparison between two operands.
	/// Uses the "&lt;&gt;" operator with precedence 50.
	/// </summary>
	public class NotEqual : ComparisonInfixOperation {
		/// <summary>
		/// Initializes a new instance of the NotEqual class with operator "&lt;&gt;" and precedence 50.
		/// </summary>
		public NotEqual() : base("<>", 50) { }

		/// <summary>
		/// Interprets the comparison result to determine if the operands are not equal.
		/// </summary>
		/// <param name="comparisonResult">The result from comparing the operands (-1, 0, or 1).</param>
		/// <returns>true if the operands are not equal (comparison result is not 0); otherwise, false.</returns>
		public override bool Interpret(int comparisonResult) {
			return comparisonResult != 0;
		}
	}
}
