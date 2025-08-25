using System.Collections.Generic;

namespace Albatross.Expression.Nodes {
	public interface IPrefixExpression : IExpression {
		string Name { get; }
		int MinOperandCount { get; }
		int MaxOperandCount { get; }
		IReadOnlyList<IExpression> Operands { get; set; }
	}
}