using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using System.Xml;

namespace Albatross.Expression.Operations {
	/// <summary>
	/// Infix operation that perform an mod operation
	/// Operand Count: 2
	/// <list type="number">
	///		<listheader>
	///		<description>Operands</description>
	///		</listheader>
	///		<item><description>Operrand1 : double</description></item>
	///		<item><description>Operrand2 : double</description></item>
	/// </list>
	/// Output Type: double
	/// </summary>
	[ParserOperation]
	public class Mod : InfixOperationToken {

		public override string Name { get { return "%"; } }
		public override bool Symbolic { get { return true; } }
		public override int Precedence { get { return 200; } }

		public override object EvalValue(Func<string, object> context) {
			object a = Operand1.EvalValue(context);
			object b = Operand2.EvalValue(context);

			if (a == null || b == null) { return null; }

			if (a is double && b is double){
				return (double)a % (double)b;
			} else {
				throw new Exceptions.UnexpectedTypeException(a.GetType());
			}
		}
	}
}
