using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Albatross.Expression.Tokens;
using System.Xml;
using Albatross.Expression.Numeric;

namespace Albatross.Expression.Operations {
	/// <summary>
	/// <para>Infix operation that perform an multiply operation</para>
	/// <para>Operand Count: 2</para>
	/// <list type="number">
	///		<listheader>
	///		<description>Operands</description>
	///		</listheader>
	///		<item><description>Operrand1 : double</description></item>
	///		<item><description>Operrand2 : double</description></item>
	/// </list>
	/// <para>Output Type: double</para>
	/// </summary>
	[ParserOperation]
	public class Multiply : InfixOperationToken {
		private readonly IMultiplyNumber multiplyNumber;

		public Multiply(IMultiplyNumber multiplyNumber) {
			this.multiplyNumber = multiplyNumber;
		}

		public override string Name { get { return "*"; } }
		public override bool Symbolic { get { return true; } }
		public override int Precedence { get { return 200; } }

		public override object EvalValue(Func<string, object> context) {
			object a = Operand1.EvalValue(context);
			object b = Operand2.EvalValue(context);
			return multiplyNumber.Run(a, b);
		}
	}
}
