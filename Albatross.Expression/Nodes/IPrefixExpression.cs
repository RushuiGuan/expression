using System.Collections.Generic;

namespace Albatross.Expression.Nodes {
	/// <summary>
	/// Represents a prefix function expression that takes a variable number of operands (e.g., Max(1, 2, 3)).
	/// </summary>
	public interface IPrefixExpression : IExpression {
		/// <summary>
		/// The name of the prefix function.
		/// </summary>
		string Name { get; }
		
		/// <summary>
		/// The minimum number of operands this function requires.
		/// </summary>
		int MinOperandCount { get; }
		
		/// <summary>
		/// The maximum number of operands this function accepts.
		/// </summary>
		int MaxOperandCount { get; }
		
		/// <summary>
		/// The list of operand expressions passed to this function.
		/// </summary>
		IReadOnlyList<IExpression> Operands { get; set; }
	}
}