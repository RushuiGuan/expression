using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using System.Xml;

namespace Albatross.Expression.Operations {
	/// <summary>
	/// Infix OR operation.
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
	/// Usage: 3 > 2 or 2 > 1
	/// Precedance: 20
	/// </summary>
	[ParserOperation]
	public class Or : InfixOperationToken {
		
		public override string Name { get { return "or"; } }
		public override bool Symbolic { get { return true; } }
		public override int Precedence { get { return 20; } }

		public override object EvalValue(Func<string, object> context) {
			object value = Operand1.EvalValue(context);
			if (value.ConvertToBoolean()) {
				return true;
			} else {
				value = Operand2.EvalValue(context);
				return value.ConvertToBoolean();
			}
		}
	}
}
