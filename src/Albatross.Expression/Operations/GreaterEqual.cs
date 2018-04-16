using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using System.Xml;

namespace Albatross.Expression.Operations {
	/// <summary>
	/// Infix GreaterEqual operation.
	/// 
	/// /// Operand Count: 2
	/// <list type="number">
	///		<listheader>
	///		<description>Operands</description>
	///		</listheader>
	///		<item><description>Operand1 : any</description></item>
	///		<item><description>Operand2 : any</description></item>
	/// </list>
	/// 
	/// Output Type: Boolean
	/// Usage: 3 >= 2
	/// Precedance: 50
	/// </summary>
	[ParserOperation]
	public class GreaterEqual : ComparisonInfixOperation {
		
		public override string Name { get { return ">="; } }
		public override bool Symbolic { get { return true; } }
		public override int Precedence { get { return 50; } }

		public override bool interpret(int comparisonResult) {
			return comparisonResult >= 0;
		}
	}
}
